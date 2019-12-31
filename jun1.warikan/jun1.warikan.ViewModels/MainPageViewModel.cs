using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jun1.warikan.ViewModels
{
    /// <summary>
    /// メインページ
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService">ナビゲーション</param>
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            base.Title = "Main Page";
            _members = new ObservableCollection<Member>();
            this.CalculateButton = new DelegateCommand(Calculate);
            this.AddMemberButton = new DelegateCommand(AddMember);
        }

        /// <summary>
        /// 計算
        /// </summary>
        private async void Calculate()
        {
            if (this.Members.Any() == false)
            {
                await Application.Current.MainPage.DisplayAlert("Error!","参加者を登録してください。","閉じる");
                return;
            }
            if (this.TotalPrice <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "合計額を入力してください。", "閉じる");
                return;
            }
            var divided = decimal.Truncate(decimal.Divide(this.TotalPrice, this.Members.Count));
            var fraction = this.TotalPrice % this.Members.Count;
            foreach(var member in this.Members)
            {
                member.Amount = divided;
            }
            this.Members.First().Amount = divided + fraction;
        }

        /// <summary>
        /// 参加者追加
        /// </summary>
        private void AddMember()
        {
            var member = new Member { Name = this.NewMemberName };
            this.Members.Add(member);
            this.NewMemberName = string.Empty;
        }

        #region イベント関連
        /// <summary>計算ボタンイベント</summary>
        public DelegateCommand CalculateButton { get; set; }
        /// <summary>参加者追加ボタン</summary>
        public DelegateCommand AddMemberButton { get; set; }
        #endregion

        #region プロパティ
        private decimal _totalPrice;
        /// <summary>合計金額</summary>
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { SetProperty(ref _totalPrice, value); }
        }
        private ObservableCollection<Member> _members;
        /// <summary>参加者</summary>
        public ObservableCollection<Member> Members
        {
            get { return _members; }
            set { SetProperty(ref _members, value); }
        }

        private string _newMemberName;
        /// <summary>新規参加者名</summary>
        public string NewMemberName
        {
            get { return _newMemberName; }
            set { SetProperty(ref _newMemberName, value); }
        }
        #endregion
    }
}
