<%--<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsJobProject._Default" %>--%>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsJobProject._Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>News</title>
    <link rel="stylesheet" type="text/css" href="Styles/News.css">
    <script src="Scripts/News.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body>
    <h1>Google News</h1>
    <form id="form1" runat="server">
        <div class="container">
            <div id="right-side">
                <h2>Topics</h2>
                <asp:Repeater ID="Repeater" runat="server">
                    <ItemTemplate>
                        <div id="news-lists" class="news-item">
                            <a href="javascript:void(0);" onclick="getNews(<%# Container.ItemIndex + 1 %>)">
                                <h3><%# Container.DataItem?.ToString() %></h3>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="left-side">
                <h2 id="h2-post">Posts</h2>
                <div id="body-post">
                </div>
            </div>

        </div>
    </form>
</body>
</html>
