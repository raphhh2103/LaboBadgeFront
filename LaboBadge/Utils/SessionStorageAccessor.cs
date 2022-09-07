using Microsoft.JSInterop;

namespace LaboBadge.Utils
{
    public class SessionStorageAccessor : IAsyncDisposable
    {
        private Lazy<IJSObjectReference> _accessorJsRef = new();
        private readonly IJSRuntime _runtime;

        public SessionStorageAccessor(IJSRuntime jSRuntime)
        {
            this._runtime = jSRuntime;

        }
        public async Task<T> GetValueAsync<T>(string key)
        {
            await WaitForReference();
            var result = await _accessorJsRef.Value.InvokeAsync<T>("get", key);

            return result;

        }
        public async Task SetValueAsync<T>(string key , T value)
        {
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("set", key, value);
        }
        public async Task Clear()
        {
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("clear");
        }
        public async Task RemoveAsync(string key)
        {
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("remove", key);

        }


        private async Task WaitForReference()
        {
            if (_accessorJsRef.IsValueCreated is false)
            {
                _accessorJsRef = new(await _runtime.InvokeAsync<IJSObjectReference>("import", "/js/SessionStorageAccessor.js"));
            }
        }
        public async ValueTask DisposeAsync()
        {
            if (_accessorJsRef.IsValueCreated)
            {
                await _accessorJsRef.Value.DisposeAsync();
            }
        }
    }
}
