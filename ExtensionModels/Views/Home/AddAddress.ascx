<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<ul class="addresses">
    <% foreach (var address in ((ExtensionModels.Core.Person)ViewData["person"]).Addresses)	{ %>
    <li><%= address %></li>
	<% } %>
</ul>