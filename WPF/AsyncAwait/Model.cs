namespace AsyncAwait
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class Model
    {
        #region Methods

        internal static async Task<string> GetMessageAsync()
        {
            var task = await Task.Run(
                () => {
                    Thread.Sleep(1200);
                    return DateTime.Now.ToLongTimeString();
                });
            return task;
        }

        #endregion
    }
}