# LMT Blazor Utils
Awesome utils for Blazor!
These libraries DO NOT work with server-side Blazor!

BlazorUtils.Dom 0.4.0 is available!: https://blazorutils.wordpress.com/2018/09/21/blazorutils-dom-0-4-0-is-available/

<p>Dependencies: jQuery version: 3.3.1 (Js file only), jQuery UI 1.12.1 (js file and jquery-ui.css), Twitter Bootstrap 4 (css and bundle)</p>
<p>Progress tables: </p>
<p>https://leminhtanvatcyahoocomvn.sharepoint.com/:x:/g/EbUBvT0Y_cJFquIPgbxJMzsBZ2HhCoYD1Uc-DRhNkoAG7A?e=cpbeZR</p>

Warning: I'm not going to develop the template anymore, since it could be quickly obsoleted compared to Blazor development. Also, the Js library will not have the minified version anymore. After all, the file is only less than 100KB.

<h1>I. Features</h1>

<p>This collection of libraries was created to improve Blazor developing experience. You don't need to type interop codes anymore, just work with front-end like you used to do - in Js/jQuery old style.</p>

<p>I created BlazorUtils.WebTest as a testing project. You may use it as a demo</p>

<p>LMT Blazor Utils has started only few days ago. Every comment, feedback sending to leminhtanvatc@outlook.com is appreciated.</p>
<p>Here is the list of all utils in Blazor Utils (updating)</p>

<table>
<thead>
  <tr>
    <td><b>Name</b></td>
    <td><b>Description</b></td>
    <td><b>Interface version dependencies</b></td>
    <td><b>Progress</b></td>
  </tr>
  </thead>
  <tbody>
    <tr>
      <td>Dom (BlazorUtils.Dom)</td>
      <td>Accessing and modifying DOM elements in the friendly jQuery style</td>
      <td>>= 0.2 with ver 0.1, 0.2, 0.2.1, >= 0.2.1 with ver 0.2.2, >= 0.2.2 with ver 0.3.1, >= 0.2.3 with ver 0.3.4, >=0.2.4 with ver 0.3.5, >=0.3.0 with ver 0.4.0, >=0.3.2 with ver 0.5.0 and 0.5.1</td>
      <td>30%</td>
    </tr>
        <tr>
      <td>Cookie (BlazorUtils.Cookie)</td>
      <td>Managing cookies</td>
      <td>>= 0.1 with ver 0.1, >= 0.2 with ver 0.2, >= 0.2.1 with ver 0.2.1, >= 0.2.2 with ver 0.2.2, >=0.3.0 with ver 0.3.0, >=0.3.2 with ver 0.4.0</td>
      <td>100%</td>
    </tr>
	        <tr>
      <td>Dev (BlazorUtils.Dev)</td>
      <td>Providing dev tool for easier developing</td>
      <td>N/A (DOM dependence)</td>
      <td>60%</td>
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
  <li>Js library (bundle): https://www.nuget.org/packages/LMT.BlazorUtils.Js.Bundle/ (this will add BlazorUtils.Js automatically to HTML head section, but without dependencies)</li>
  </ol>
<p>As an alternative, you can build the project (BlazorUtils.Dom for example) to get the dll file and add reference by yourself.</p>

<h2>2. Add BlazorUtils js library 0.4.1 and dependencies</h2>
<p>Copy BlazorUtils.0.4.1.js or BlazorUtils.0.4.1.bundle.js from "\BlazorUtils.WebTest.0.5\wwwroot\js", paste in your project, call it and other dependencies' files in index.html by the <script> and <link> tags.</p>
<p>With BlazorUtils.Dom, the result should be similar to this: </p>

```
<link href="css/jquery-ui.css" rel="stylesheet"/>
<link href="css/bootstrap.min.css" rel="stylesheet"/>
<script type="text/javascript" src="js/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="js/jquery-ui.min.js"></script>
<script type="text/javascript" src="js/bootstrap.bundle.min.js"></script>
<script type="text/javascript" src="js/lottie.min.js"></script>
<script type="text/javascript" src="js/BlazorUtils.0.4.1.js"></script>
```
Or using Blazor Utils bundled version (recommended, CDN - require internet connection):

```
<script type="text/javascript" src="js/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="js/BlazorUtils.0.4.1.bundle.js"></script>
```

<p>If you only use BlazorUtils.Cookie: </p>

```
<script type="text/javascript" src="js/BlazorUtils.0.4.1.js"></script>
```

<h2>3. Add these lines to _ViewImports.cshtml (remove the last one if you don't use Dev)</h2>

```
@addTagHelper *, BlazorUtils.Dom
@using static BlazorUtils.Dom.DomUtils
@using BlazorUtils.Cookie
@using BlazorUtils.Interfaces.EventArgs
@using BlazorUtils.Dom.BlazorComponents
@using BlazorUtils.Dev
```

<p>This will help you call my API faster, without calling DomUtil, Cookies over and over again.</p>