using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSoftorApp.ViewModels.Infrastructure
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {

        #region isbusy 防止资源共享而死锁
        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }
        #endregion

        #region init 派身高对象中用于数据初始化
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
        #endregion

    }
}
