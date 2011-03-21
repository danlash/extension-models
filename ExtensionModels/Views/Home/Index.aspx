<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ExtensionModels Age Calculator</title>
    <link rel="Stylesheet" href="http://yui.yahooapis.com/3.3.0/build/cssreset/reset-min.css" />
    <style>
            body
            {
                font-size: 14px;
                font-family: Arial, Sans-Serif;
                padding: 1em;
            }
            
            .input label
            {
                display: block;
                font-weight: bold;
                margin-top: 1em;
            }
            
            .input input 
            {
                margin-top: 0.5em;
            }
            
            .input [type=submit]
            {
                display: block;
                margin-top: 1em;
            }
            
            .output 
            {
                font-size: 2em;
                margin: 2em;
            }
    </style>
</head>
<body>
    <section class="age">
        <header>Calculate Age</header>
        <form action="<%= Url.Action("CalculateAge") %>" method="post">
            <label for="name">Name</label>
            <input type="text" required="required" name="Name" id="name" autofocus />

            <label for="date_of_birth">Date of Birth</label>
            <label for="date_of_birth" class="format"><%= ((DateTime)ViewData["CurrentDate"]).ToString("yyyy-MM-dd") %></label>
            <input type="date" required="required" name="DateOfBirth" id="date_of_birth"
                    min="<%= ((DateTime)ViewData["MinimumDate"]).ToString("yyyy-MM-dd") %>" 
                    max="<%= ((DateTime)ViewData["MaximumDate"]).ToString("yyyy-MM-dd") %>"  />

            <button type="submit">Calculate Age</button>
        </form>
        <output for="date_of_birth"></output>
    </section>
    

    <section class="address">
        <header>Add Address</header>
        <form action="<%= Url.Action("AddAddress") %>" method="post">
            <label for="person">Person</label>
            <select name="personId", id="person">
                <option value="1">Dan Lash</option>
            </select>

            <label for="address">Address</label>
            <input type="text" required="required" name="Address" id="address" 
            placeholder="897 N Highland Ave NE, APT BT2, Atlanta, GA 30306" />

            <button type="submit">Add Address</button>
        </form>
        <output for="date_of_birth"></output>
    </section>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery-ui/1.8.11/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $.each(['.age', '.address'], function () {
                var $container = $(this.toString());
                
                $('form', $container).submit(function (e) {
                    e.preventDefault();

                    var $form = $(this);
                    var url = $form.attr('action');
                    var method = $form.attr('method');

                    $.ajax({
                        url: url,
                        type: method,
                        data: $form.serialize(),
                        success: function (result) {
                            $('output', $container).html(result);
                        }
                    });
                });
            });

        });
    </script>
</body>
</html>
