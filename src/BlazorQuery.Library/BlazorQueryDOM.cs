using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorQuery.Library.Elements;

namespace BlazorQuery.Library
{

    public class BlazorQueryDOM : ComponentBase
    {
        private IJSRuntime JsRuntime { get; }

        public List<BlazorQueryDOMElement> Elements { get; private set; }

        private string CurrentSelector { get; set; }

        public BlazorQueryDOM(IJSRuntime jsRuntime)
        {
            JsRuntime = jsRuntime;
            Elements = new List<BlazorQueryDOMElement>();
        }

        public async Task<BlazorQueryDOM> Select(string selector)
        {
            var data = await JsRuntime.InvokeAsync<string>(BlazorQueryList.Select, selector);

            return new BlazorQueryDOM(JsRuntime)
            {
                CurrentSelector = selector,
                Elements = JsonSerializer.Deserialize<List<BlazorQueryDOMElement>>(data)
            };
        }

        // Utilities
        public async Task Alert(string message) => await JsRuntime.InvokeAsync<Task>(BlazorQueryList.Utils_Alert, message);

        public async Task ConsoleLog(string message) => await JsRuntime.InvokeAsync<Task>(BlazorQueryList.Utils_ConsoleLog, message);

        // Functions - Actions
        public async Task<BlazorQueryDOM> AddClass(string className) { await JsRuntime.InvokeAsync<Task>(BlazorQueryList.AddClass, CurrentSelector, className); return this; }

        public async Task<BlazorQueryDOM> RemoveClass(string className) { await JsRuntime.InvokeAsync<Task>(BlazorQueryList.RemoveClass, CurrentSelector, className); return this; }

        public async Task<BlazorQueryDOM> CSS(string style, string styleValue) { await JsRuntime.InvokeAsync<Task>(BlazorQueryList.CSS, CurrentSelector, style, styleValue); return this; }

        public async Task<BlazorQueryDOM> Height(double height) { await JsRuntime.InvokeAsync<Task>(BlazorQueryList.Height_Set, CurrentSelector, height); return this; }

        public async Task<BlazorQueryDOM> Width(double width) { await JsRuntime.InvokeAsync<Task>(BlazorQueryList.Width_Set, CurrentSelector, width); return this; }

        public async Task<BlazorQueryDOM> Text(string text) { await JsRuntime.InvokeAsync<Task>(BlazorQueryList.Text_Set, CurrentSelector, text); return this; }

        public async Task<BlazorQueryDOM> FadeOut(Action<string> completed)
        {
            var actionWrapper = new ActionWrapper<string>(completed);
            var dotNetObjectReference = DotNetObjectReference.Create(actionWrapper);
            await JsRuntime.InvokeAsync<Task>(BlazorQueryList.FadeOut, CurrentSelector, dotNetObjectReference);
            return this;
        }

        // Functions - Chain-enders
        public async Task<double> Height() => await JsRuntime.InvokeAsync<double>(BlazorQueryList.Height_Get, CurrentSelector);

        public async Task<double> Width() => await JsRuntime.InvokeAsync<double>(BlazorQueryList.Width_Get, CurrentSelector);

        public async Task<string> Text() => await JsRuntime.InvokeAsync<string>(BlazorQueryList.Text_Get, CurrentSelector);
    }
}
