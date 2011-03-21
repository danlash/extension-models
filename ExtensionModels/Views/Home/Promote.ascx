<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>


<article>
	<header><%= ((ExtensionModels.Core.Employee)ViewData["employee"]).Name%>, <%= ((ExtensionModels.Core.Employee)ViewData["employee"]).Title%></header>
	<ul class="addresses">
		<% foreach (var address in ((ExtensionModels.Core.Employee)ViewData["employee"]).Addresses)	{ %>
		<li>
			<span class="name"><%= address.Name %></span>
			<address><%= address %></address>
		</li>
		<% } %>
	</ul>
</article>