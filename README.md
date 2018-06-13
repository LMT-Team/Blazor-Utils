# LMT Blazor Utils
interacting with elements with ease in Blazor! (updating)

<p>Version: 0.1 beta</p>
<p>Dependencies: jQuery version: 3.3.1 (Js file only), jQuery UI 1.12.1 (js file and jquery-ui.css)</p>
<p>Progress tables: </p>
<p>Dom (BlazorUtils.Dom): https://studenthcmuteeduvn0-my.sharepoint.com/:x:/g/personal/15110123_student_hcmute_edu_vn/EY0L_13KbWNMvDWdVJiA37UBO4Ie7muppmIseWWXKZVEfg?e=ehPsDu</p>

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
    <td><b>Version supported</b></td>
    <td><b>Progress</b></td>
  </tr>
  </thead>
  <tbody>
    <tr>
      <td>Dom (BlazorUtils.Dom)</td>
      <td>Accessing and modifying DOM elements in the friendly jQuery style</td>
      <td>>= 0.1 beta</td>
      <td>30%</td>
    </tr>
        <tr>
      <td>Dom (BlazorUtils.Cookie)</td>
      <td>Managing cookies and sessions</td>
      <td>(updating)</td>
      <td>0%</td>
    </tr>
    </tody>
</table>

<h1>II. Configurations</h1>
Things should be easy as 1, 2, 3! Just follow these steps: 
<h2>1. Add references to your project</h2>
<p>Currently, I haven't bring this to NuGet yet.</p>
<p>As an alternative, you can build the project (BlazorUtils.Dom for example) to get the dll file and add reference by yourself.</p>

<h2>2. Add BlazorUtils.0.1.js</h2>
<p>Copy BlazorUtils.0.1.js fron "\BlazorUtils.WebTest\wwwroot\js", paste in your project and call it in index.html file by a <script> tag. Then, call BlazorBoot() in body's onload attribute.</p>
<p><b>Warning: You must add jquery-ui.css, jquery-3.3.1.min.js and jquery-ui.min.js if you haven't done it yet!</b></p>

<h2>3. Add this line to _ViewImports.cshtml</h2>
<p>@using static BlazorUtils.Dom.DomUtil</p>
<p>This will help you call my API faster, without calling DomUtil over and over again.</p>
