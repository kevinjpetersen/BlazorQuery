# BlazorQuery

**Note:** Currently working to remove the jQuery dependency and make it completely Plain JS, but keep the jQuery syntax the same, without the jQuery.

BlazorQuery is a Blazor Library that wraps jQuery completely in C# so that DOM Manipulation, Ajax, etc, can be done directly without leaving the comfort of C#.

[![Nuget](https://img.shields.io/nuget/v/BlazorQuery.svg)](https://www.nuget.org/packages/BlazorQuery) [![GitHub](https://img.shields.io/github/license/kevinjpetersen/BlazorQuery.svg)](https://github.com/kevinjpetersen/BlazorQuery/blob/master/LICENSE)

## How to get started
1. Install ``BlazorQuery`` through [Nuget](https://www.nuget.org/packages/BlazorQuery): ```Install-Package BlazorQuery```
2. Add the following in your applications ``_Host.cshtml`` file (jQuery) (If you already have jQuery, you can skip this step):
```javascript
<script src="_content/BlazorQuery/jQuery.js"></script>
```
3. Add the following in your applications ``_Host.cshtml`` file, AFTER your jQuery script tag: 
```javascript
<script src="_content/BlazorQuery/blazorQuery.js"></script>
```
4. Add the following Service to your applications ``Startup.cs`` file:
```csharp
services.AddBlazorQuery();
```
5. Setup is done, you can now go to "Usage" section

## Usage
**IMPORTANT NOTE:** A current limitation of Blazor means you cannot execute DOM Manipulation in a Prerendering state, so you can only use ``DOM`` functions in ``OnAfterRenderAsync`` or AFTER Prerendering has been done (For example through a button click or an eventhandler, etc.)

**Example - CSS**
```razor
@page "/"
@inject BlazorQueryDOM DOM

<h1>Hello, DOM!</h1>
<h1>Hello, Blazor!</h1>

@code {
    protected override async Task OnAfterRenderAsync()
    {
      await DOM.Select("h1").CSS("background-color", "red");
    }
}
```

**Example - Text**
```razor
@page "/"
@inject BlazorQueryDOM DOM

<h1>Hello, DOM!</h1>
<h1>Hello, Blazor!</h1>

@code {
    protected override async Task OnAfterRenderAsync()
    {
      await DOM.Select("h1").Text("Now this text is changed");
    }
}
```

**Example - Combining Actions**
```razor
@page "/"
@inject BlazorQueryDOM DOM

<h1>Hello, DOM!</h1>
<h1>Hello, Blazor!</h1>

@code {
    protected override async Task OnAfterRenderAsync()
    {
      await DOM.Select("h1").Text("Now this text is changed").CSS("color", "yellow");
    }
}
```

## Change log
- **Version 0.0.3 - 2021-05-01**
  - Migrated to .NET 5 and updated all packages to .NET 5 versions
  - Some cleanup, such as moving BlazorQueryDOMHelpers to a new file
  - Fixed a bug where Height and Width on DOM element needed to be double
  - Added "href" to DOM element
- **Version 0.0.2 - 2020-07-29**
  - Functionality added
    - Update projects to build with latest version of Blazor
	- Migration from blazor preview --> blazor release
	- Starting wrapping fadein and fadeout
	- New testapp to test with blazor webassembly, and refactoring to make common code between the 2 testaspp
- **Version 0.0.1 - 2019-07-09**
  - Functionality added
    - Added Select (Equivalent to $/jQuery, to select elements)
    - Added AddClass, RemoveClass, 
    - Added Height (Set & Get), Width (Set & Get)
    - Added Text (Set & Get)
    - Added CSS

## Contributors
- **Kevin J. Petersen https://github.com/kevinjpetersen**
- **Sybaris https://github.com/sybaris**
- **AmazingAlek https://github.com/amazingalek**

## Full list of functionality currently supported (In alphabetical order)
- [ ] Add 
- [ ] AddBack 
- [x] AddClass 
- [ ] After 
- [ ] AjaxComplete 
- [ ] AjaxError 
- [ ] AjaxSend 
- [ ] AjaxStart 
- [ ] AjaxStop 
- [ ] AjaxSuccess 
- [ ] AndSelf 
- [ ] Animate 
- [ ] Append 
- [ ] AppendTo 
- [ ] Attr 
- [ ] Before 
- [ ] Bind 
- [ ] Blur 
- [ ] Change 
- [ ] Children 
- [ ] ClearQueue 
- [ ] Click 
- [ ] Clone 
- [ ] Closest 
- [ ] Context 
- [ ] ContextMenu 
- [x] CSS 
- [ ] Data 
- [ ] DBLClick 
- [ ] Delay 
- [ ] DelegateJS 
- [ ] Dequeue 
- [ ] Detach 
- [ ] Die 
- [ ] Each 
- [ ] Empty 
- [ ] End 
- [ ] Eq 
- [ ] Error 
- [ ] FadeIn 
- [ ] FadeOut 
- [ ] FadeTo 
- [ ] FadeToggle 
- [ ] Filter 
- [ ] Find 
- [ ] Finish 
- [ ] First 
- [ ] Focus 
- [ ] FocusIn 
- [ ] FocusOut 
- [ ] Get 
- [ ] Has 
- [ ] HasClass 
- [x] Height_Set 
- [x] Height_Get 
- [ ] Hide 
- [ ] Hover 
- [ ] Html 
- [ ] Index 
- [ ] InnerHeight 
- [ ] InnerWidth 
- [ ] InsertAfter 
- [ ] InsertBefore 
- [ ] Is 
- [ ] jQuery 
- [ ] KeyDown 
- [ ] KeyPress 
- [ ] KeyUp 
- [ ] Last 
- [ ] Length 
- [ ] Live 
- [ ] Load 
- [ ] Map 
- [ ] MouseDown 
- [ ] MouseEnter 
- [ ] MouseLeave 
- [ ] MouseMove 
- [ ] MouseOut 
- [ ] MouseOver 
- [ ] MouseUp 
- [ ] Next 
- [ ] NextAll 
- [ ] NextUntil 
- [ ] Not 
- [ ] Off 
- [ ] Offset 
- [ ] OffsetParent 
- [ ] On 
- [ ] One 
- [ ] OuterHeight 
- [ ] OuterWidth 
- [ ] Parent 
- [ ] Parents 
- [ ] ParentsUntil 
- [ ] Position 
- [ ] Prepend 
- [ ] PrependTo 
- [ ] Prev 
- [ ] PrevAll 
- [ ] PrevUntil 
- [ ] Promise 
- [ ] Prop 
- [ ] PushStack 
- [ ] Queue 
- [ ] Ready 
- [ ] Remove 
- [ ] RemoveAttr 
- [x] RemoveClass 
- [ ] RemoveData 
- [ ] RemoveProp 
- [ ] ReplaceAll 
- [ ] ReplaceWith 
- [ ] Resize 
- [ ] Scroll 
- [ ] ScrollLeft 
- [ ] ScrollTop 
- [x] Select (Equivalent to $/jQuery, to select elements)
- [ ] SelectJS 
- [ ] Serialize 
- [ ] SerializeArray 
- [ ] Show 
- [ ] Siblings 
- [ ] Size 
- [ ] Slice 
- [ ] SlideDown 
- [ ] SlideToggle 
- [ ] SlideUp 
- [ ] Stop 
- [ ] Submit 
- [x] Text_Set 
- [x] Text_Get 
- [ ] ToArray 
- [ ] Toggle 
- [ ] ToggleClass 
- [ ] Trigger 
- [ ] TriggerHandler 
- [ ] Unbind 
- [ ] Undelegate 
- [ ] Unload 
- [ ] Unwrap 
- [ ] Val 
- [x] Width_Set 
- [x] Width_Get 
- [ ] Wrap 
- [ ] WrapAll 
- [ ] WrapInner 
