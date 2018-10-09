# LMT Blazor Utils
Awesome utils for Blazor!

[![Join the chat at https://gitter.im/Blazor-Utils](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/Blazor-Utils) 

Currently, Blazor Utils doesn't fully support server-side Blazor (jQuery callbacks and integrated components depending on them don't work).

BlazorUtils.Dom 0.5.0 is available!: https://blazorutils.wordpress.com/2018/10/05/blazorutils-dom-0-5-0-release-notes/

<p>Dependencies: jQuery version: 3.3.1 (Js file only), jQuery UI 1.12.1 (js file and jquery-ui.css), Twitter Bootstrap 4 (css and bundle)</p>
<p>Progress tables: </p>
<p>https://leminhtanvatcyahoocomvn.sharepoint.com/:x:/g/EbUBvT0Y_cJFquIPgbxJMzsBZ2HhCoYD1Uc-DRhNkoAG7A?e=cpbeZR</p>

Warning: I'm not going to develop the template anymore, since it could be quickly obsoleted compared to Blazor development. Also, the Js library will not have the minified version anymore. After all, the file is only less than 100KB.

<h1>I. Features</h1>

<p>This collection of libraries was created to improve Blazor developing experience. You don't need to type interop codes anymore, just work with front-end like you used to do - in Js/jQuery old style.</p>

<p>I created BlazorUtils.WebTest as a testing project. You may use it as a demo</p>

<p>LMT Blazor Utils has started only few days ago. Every comment, feedbacks sent to leminhtanvatc@outlook.com are appreciated.</p>
<p>Here is the list of all utils in Blazor Utils (updating)</p>

<table>
<thead>
  <tr>
    <td><b>Name</b></td>
    <td><b>Description</b></td>
    <td><b>Js library version dependencies</b></td>
  </tr>
  </thead>
  <tbody>
    <tr>
      <td>Dom (BlazorUtils.Dom)</td>
      <td>Accessing and modifying DOM elements in the friendly jQuery style</td>
      <td>>= 0.4.3 with ver 0.5.3</td>
    </tr>
        <tr>
      <td>Cookie (BlazorUtils.Cookie)</td>
      <td>Managing cookies</td>
      <td>>= 0.4.1 with ver 0.4.0</td>
    </tr>
	        <tr>
      <td>Dev (BlazorUtils.Dev)</td>
      <td>Providing dev tool for easier developing</td>
      <td>N/A (DOM dependence)</td>
    </tr>
    </tody>
</table>

<h1>II. Configurations</h1>
Things should be easy as 1, 2, 3! Just follow these steps: 
<h2>1. Add references to your project</h2>
<p><del>Currently, I haven't bring this to NuGet yet.</del></p>
<p>Great news! NuGet packages are available: </p>
<ol>
  <li>Interfaces: https://www.nuget.org/packages/LMT.BlazorUtils.Interfaces/</li>
  <li>Dom: https://www.nuget.org/packages/LMT.BlazorUtils.Dom/</li>
  <li>Cookie: https://www.nuget.org/packages/LMT.BlazorUtils.Cookie/</li>
  <li>Dev: https://www.nuget.org/packages/LMT.BlazorUtils.Dev/</li>
  <li>Js library: https://www.nuget.org/packages/LMT.BlazorUtils.Js/ (this will add BlazorUtils.Js automatically to HTML head section, but without dependencies)</li>
  <li>Js library (bundle): https://www.nuget.org/packages/LMT.BlazorUtils.Js.Bundle/ (this will add BlazorUtils.Js automatically to HTML head section. From 0.4.2, you can use this package offline)</li>
  </ol>
<p>As an alternative, you can build the project (BlazorUtils.Dom for example) to get the dll file and add reference by yourself.</p>

<h2>2. Add BlazorUtils js library and dependencies</h2>
<p>Install BlazorUtils.Js package from NuGet.</p>
<p>For non-bundled version, index.html needs some additional lines: </p>

```
<link href="css/jquery-ui.css" rel="stylesheet"/>
<link href="css/bootstrap.min.css" rel="stylesheet"/>
<link href="css/featherlight.min.css" rel="stylesheet"/>
<script type="text/javascript" src="js/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="js/jquery-ui.min.js"></script>
<script type="text/javascript" src="js/bootstrap.bundle.min.js"></script>
<script type="text/javascript" src="js/lottie.min.js"></script>
<script type="text/javascript" src="js/featherlight.min.js"></script>
```

<h2>3. Add these lines to _ViewImports.cshtml (remove the last one if you don't use Dev)</h2>

```
@using static BlazorUtils.Dom.DomUtils
@using BlazorUtils.Dom.BlazorUtilsComponents
@using BlazorUtils.Interfaces.EventArgs
@using BlazorUtils.Cookie
@using BlazorUtils.Dev
```

<p>This will help you call my API faster, without calling DomUtil, Cookies over and over again.</p>
