using System;
using System.Reflection;

namespace jun1.warikan.ViewModels
{
    /// <summary>
    /// ViewModel取得ルール定義
    /// </summary>
    public static class ViewTypeToViewModelTypeResolver
    {
        /// <summary>自アセンブリ</summary>
        private static readonly Assembly LocalAssembly = typeof(ViewTypeToViewModelTypeResolver).Assembly;

        /// <summary>
        /// ViewModelの型取得
        /// </summary>
        /// <param name="viewType">呼び出し元Viewクラス</param>
        /// <returns>ViewModelの型</returns>
        public static Type Resolve(Type viewType)
        {
            if (viewType == null) throw new ArgumentNullException(nameof(viewType));

            var vmTypeName = $"{viewType.Namespace.Replace("Views", "ViewModels")}.{viewType.Name}ViewModel";
            return LocalAssembly.GetType(vmTypeName);
        }
    }
}
