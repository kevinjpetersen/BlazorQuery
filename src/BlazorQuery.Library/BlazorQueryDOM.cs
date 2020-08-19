using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorQuery.Library
{

    public class BlazorQueryDOM : ComponentBase
    {
        private IJSRuntime JSRuntime { get; set; }

        public List<BlazorQueryDOMElement> Elements { get; private set; }
        private string CurrentSelector { get; set; }

        public BlazorQueryDOM(IJSRuntime JSRuntime)
        {
            this.JSRuntime = JSRuntime;
            Elements = new List<BlazorQueryDOMElement>();
        }

        public async Task<BlazorQueryDOM> Select(string selector)
        {
            BlazorQueryDOM dom = new BlazorQueryDOM(JSRuntime);
            dom.CurrentSelector = selector;
            var data = await JSRuntime.InvokeAsync<string>(BlazorQueryList.Select, selector);
            dom.Elements = JsonSerializer.Deserialize<List<BlazorQueryDOMElement>>(data);

            return dom;
        }

        // Utilities
        public async Task Alert(string message) => await JSRuntime.InvokeAsync<Task>(BlazorQueryList.Utils_Alert, message);
        public async Task ConsoleLog(string message) => await JSRuntime.InvokeAsync<Task>(BlazorQueryList.Utils_ConsoleLog, message);

        // Functions - Actions
        public async Task<BlazorQueryDOM> AddClass(string className) { await JSRuntime.InvokeAsync<Task>(BlazorQueryList.AddClass, CurrentSelector, className); return this; }
        public async Task<BlazorQueryDOM> RemoveClass(string className) { await JSRuntime.InvokeAsync<Task>(BlazorQueryList.RemoveClass, CurrentSelector, className); return this; }
        public async Task<BlazorQueryDOM> CSS(string style, string styleValue) { await JSRuntime.InvokeAsync<Task>(BlazorQueryList.CSS, CurrentSelector, style, styleValue); return this; }
        public async Task<BlazorQueryDOM> Height(int height) { await JSRuntime.InvokeAsync<Task>(BlazorQueryList.Height_Set, CurrentSelector, height); return this; }
        public async Task<BlazorQueryDOM> Width(int width) { await JSRuntime.InvokeAsync<Task>(BlazorQueryList.Width_Set, CurrentSelector, width); return this; }
        public async Task<BlazorQueryDOM> Text(string text) { await JSRuntime.InvokeAsync<Task>(BlazorQueryList.Text_Set, CurrentSelector, text); return this; }
        public async Task<BlazorQueryDOM> FadeOut(Action<string> completed) 
        {
            var actionWrapper = new ActionWrapper<string>(completed);
            var dotNetObjectReference = DotNetObjectReference.Create(actionWrapper);
            await JSRuntime.InvokeAsync<Task>(BlazorQueryList.FadeOut, CurrentSelector, dotNetObjectReference); 
            return this; 
        }

        // Functions - Chain-enders
        public async Task<int> Height() => await JSRuntime.InvokeAsync<int>(BlazorQueryList.Height_Get, CurrentSelector);
        public async Task<int> Width() => await JSRuntime.InvokeAsync<int>(BlazorQueryList.Width_Get, CurrentSelector);
        public async Task<string> Text() => await JSRuntime.InvokeAsync<string>(BlazorQueryList.Text_Get, CurrentSelector);

    }

    public static class BlazorQueryDOMHelpers
    {
        // Functions - Actions
        public async static Task<BlazorQueryDOM> AddClass(this Task<BlazorQueryDOM> dom, string className) => await (await dom).AddClass(className);
        public async static Task<BlazorQueryDOM> RemoveClass(this Task<BlazorQueryDOM> dom, string className) => await (await dom).RemoveClass(className);
        public async static Task<BlazorQueryDOM> CSS(this Task<BlazorQueryDOM> dom, string style, string styleValue) => await (await dom).CSS(style, styleValue);
        public async static Task<BlazorQueryDOM> Height(this Task<BlazorQueryDOM> dom, int height) => await (await dom).Height(height);
        public async static Task<BlazorQueryDOM> Width(this Task<BlazorQueryDOM> dom, int width) => await (await dom).Width(width);
        public async static Task<BlazorQueryDOM> Text(this Task<BlazorQueryDOM> dom, string text) => await (await dom).Text(text);
        public async static Task<BlazorQueryDOM> FadeOut(this Task<BlazorQueryDOM> dom, Action<string> completed) => await (await dom).FadeOut(completed);

        // Functions - Chain-enders
        public async static Task<int> Height(this Task<BlazorQueryDOM> dom) => await (await dom).Height();
        public async static Task<int> Width(this Task<BlazorQueryDOM> dom) => await (await dom).Width();
        public async static Task<string> Text(this Task<BlazorQueryDOM> dom) => await (await dom).Text();
    }
}
