using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorQuery
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
            dom.Elements = JsonSerializer.Parse<List<BlazorQueryDOMElement>>(await JSRuntime.InvokeAsync<string>(BlazorQueryList.Select, selector));

            return dom;
        }

        public async Task<bool> AddClass(string className) => await JSRuntime.InvokeAsync<bool>(BlazorQueryList.AddClass, CurrentSelector, className);
        public async Task<bool> RemoveClass(string className) => await JSRuntime.InvokeAsync<bool>(BlazorQueryList.RemoveClass, CurrentSelector, className);
        public async Task<bool> CSS(string style, string styleValue) => await JSRuntime.InvokeAsync<bool>(BlazorQueryList.CSS, CurrentSelector, style, styleValue);


    }
}
