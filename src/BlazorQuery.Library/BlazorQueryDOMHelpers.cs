using System;
using System.Threading.Tasks;

namespace BlazorQuery.Library
{
	public static class BlazorQueryDOMHelpers
	{
		// Functions - Actions
		public static async Task<BlazorQueryDOM> AddClass(this Task<BlazorQueryDOM> dom, string className) => await (await dom).AddClass(className);

		public static async Task<BlazorQueryDOM> RemoveClass(this Task<BlazorQueryDOM> dom, string className) => await (await dom).RemoveClass(className);

		public static async Task<BlazorQueryDOM> CSS(this Task<BlazorQueryDOM> dom, string style, string styleValue) => await (await dom).CSS(style, styleValue);

		public static async Task<BlazorQueryDOM> Height(this Task<BlazorQueryDOM> dom, double height) => await (await dom).Height(height);

		public static async Task<BlazorQueryDOM> Width(this Task<BlazorQueryDOM> dom, double width) => await (await dom).Width(width);

		public static async Task<BlazorQueryDOM> Text(this Task<BlazorQueryDOM> dom, string text) => await (await dom).Text(text);

		public static async Task<BlazorQueryDOM> FadeOut(this Task<BlazorQueryDOM> dom, Action<string> completed) => await (await dom).FadeOut(completed);

		// Functions - Chain-enders
		public static async Task<double> Height(this Task<BlazorQueryDOM> dom) => await (await dom).Height();

		public static async Task<double> Width(this Task<BlazorQueryDOM> dom) => await (await dom).Width();

		public static async Task<string> Text(this Task<BlazorQueryDOM> dom) => await (await dom).Text();
	}
}