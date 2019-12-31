using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace jun1.warikan.ViewModels
{
    /// <summary>
    /// 参加者
    /// </summary>
    public class Member : INotifyPropertyChanged
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Member()
        {
            this.Name = string.Empty;
            this.Amount = 0m;
            this.IsPaid = false;
        }

        /// <summary>プロパティ変更イベント</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        /// <summary>名前</summary>
        public string Name 
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
                }
            }
        }
        private decimal _amount;
        /// <summary>支払額</summary>
        public decimal Amount 
        {
            get { return _amount; }
            set 
            {
                if (_amount != value)
                {
                    _amount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Amount)));
                }
            }
        }
        private bool _isPaid;
        /// <summary>支払い済みか</summary>
        public bool IsPaid 
        {
            get { return _isPaid; }
            set 
            {
                if (_isPaid != value)
                {
                    _isPaid = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsPaid)));
                }
            }
        }
    }
}
