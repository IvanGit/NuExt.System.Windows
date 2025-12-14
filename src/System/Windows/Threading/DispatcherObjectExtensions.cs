namespace System.Windows.Threading
{
    public static class DispatcherObjectExtensions
    {
        extension (DispatcherObject dispatcherObject)
        {
            /// <summary>
            /// Executes the specified delegate synchronously on the appropriate thread or context.
            /// </summary>
            /// <param name="method">A delegate to a method to invoke.</param>
            /// <param name="args">An array of objects to pass as arguments to the delegate, or <see langword="null"/>.</param>
            /// <returns>
            /// The return value from the delegate being invoked, or <see langword="null"/> if the delegate has no return value.
            /// </returns>
            /// <exception cref="ArgumentNullException">Thrown when <paramref name="method"/> is <see langword="null"/>.</exception>
            public object? Invoke(Delegate method, params object?[] args)
            {
                ArgumentNullException.ThrowIfNull(method);

                if (!dispatcherObject.CheckAccess())
                {
                    return dispatcherObject.Dispatcher.Invoke(method, args);
                }

                return method.Call(args);
            }

            /// <summary>
            /// Executes the specified <see cref="Action"/> synchronously on the thread the <see cref="DispatcherObject.Dispatcher"/> is associated with.
            /// </summary>
            /// <param name="callback">A delegate to invoke through the dispatcher.</param>
            /// <exception cref="ArgumentNullException">Thrown when the <paramref name="callback"/> parameter is null.</exception>
            public void Invoke(Action callback)
            {
                ArgumentNullException.ThrowIfNull(callback);

                if (!dispatcherObject.CheckAccess())
                {
                    dispatcherObject.Dispatcher.Invoke(callback);
                    return;
                }

                callback();
            }

            /// <summary>
            /// Executes the specified <see cref="Func{TResult}"/> synchronously on the thread that the <see cref="DispatcherObject.Dispatcher"/> is associated with.
            /// </summary>
            /// <typeparam name="TResult">The type of the callback return value.</typeparam>
            /// <param name="callback">A <see cref="Func{TResult}"/> delegate to invoke through the dispatcher.</param>
            /// <returns>The return value from the delegate being invoked.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the <paramref name="callback"/> parameter is null.</exception>
            public TResult Invoke<TResult>(Func<TResult> callback)
            {
                ArgumentNullException.ThrowIfNull(callback);

                if (!dispatcherObject.Dispatcher.CheckAccess())
                {
                    return dispatcherObject.Dispatcher.Invoke(callback);
                }

                return callback();
            }

            /// <summary>
            /// Executes the specified <see cref="Action"/> asynchronously on the thread that the <see cref="DispatcherObject.Dispatcher"/> is associated with.
            /// </summary>
            /// <param name="callback">An <see cref="Action"/> delegate to invoke through the dispatcher.</param>
            /// <returns>A Task representing the asynchronous operation.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the <paramref name="callback"/> parameter is null.</exception>
            public Task InvokeAsync(Action callback)
            {
                ArgumentNullException.ThrowIfNull(callback);

                if (!dispatcherObject.Dispatcher.CheckAccess())
                {
                    return dispatcherObject.Dispatcher.InvokeAsync(callback).Task;
                }

                try
                {
                    callback();
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
            }

            /// <summary>
            /// Executes the specified <see cref="Func{TResult}"/> asynchronously on the thread that the <see cref="DispatcherObject.Dispatcher"/> is associated with.
            /// </summary>
            /// <typeparam name="TResult">The type of the callback return value.</typeparam>
            /// <param name="callback">A <see cref="Func{TResult}"/> delegate to invoke through the dispatcher.</param>
            /// <returns>A Task representing the asynchronous operation.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the <paramref name="callback"/> parameter is null.</exception>
            public Task<TResult> InvokeAsync<TResult>(Func<TResult> callback)
            {
                ArgumentNullException.ThrowIfNull(callback);

                if (!dispatcherObject.Dispatcher.CheckAccess())
                {
                    return dispatcherObject.Dispatcher.InvokeAsync(callback).Task;
                }

                try
                {
                    TResult result = callback();
                    return Task.FromResult(result);
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
            }

            /// <summary>
            /// Executes the specified Func&lt;Task&gt; asynchronously on the thread that the <see cref="DispatcherObject.Dispatcher"/> is associated with.
            /// </summary>
            /// <param name="callback">A Func&lt;Task&gt; delegate to invoke through the dispatcher.</param>
            /// <returns>A Task representing the asynchronous operation.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the <paramref name="callback"/> parameter is null.</exception>
            public Task InvokeAsync(Func<Task> callback)
            {
                ArgumentNullException.ThrowIfNull(callback);

                if (!dispatcherObject.Dispatcher.CheckAccess())
                {
                    return dispatcherObject.Dispatcher.InvokeAsync(callback).Task.Unwrap();
                }

                try
                {
                    Task result = callback();
                    return result;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
            }

            /// <summary>
            /// Executes the specified Func&lt;Task&lt;TResult&gt;&gt; asynchronously on the thread that the <see cref="DispatcherObject.Dispatcher"/> is associated with.
            /// </summary>
            /// <typeparam name="TResult">The type of the callback return value.</typeparam>
            /// <param name="callback">A Func&lt;Task&lt;TResult&gt;&gt; delegate to invoke through the dispatcher.</param>
            /// <returns>A Task representing the asynchronous operation.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the <paramref name="callback"/> parameter is null.</exception>
            public Task<TResult> InvokeAsync<TResult>(Func<Task<TResult>> callback)
            {
                ArgumentNullException.ThrowIfNull(callback);

                if (!dispatcherObject.Dispatcher.CheckAccess())
                {
                    return dispatcherObject.Dispatcher.InvokeAsync(callback).Task.Unwrap();
                }

                try
                {
                    Task<TResult> result = callback();
                    return result;
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
            }

        }
    }
}
