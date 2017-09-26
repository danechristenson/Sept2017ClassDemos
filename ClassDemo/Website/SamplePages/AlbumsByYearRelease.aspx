<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AlbumsByYearRelease.aspx.cs" Inherits="SamplePages_AlbumsByYearRelease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Albums By Year Released</h1>
    <asp:Label ID="Label1" runat="server" Text="Enter minimum year"></asp:Label>
    <asp:TextBox ID="minYear" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Enter maximum year"></asp:Label>
    <asp:TextBox ID="maxYear" runat="server"></asp:TextBox>
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server">Submit</asp:LinkButton>
    <br />
    <br />
    <asp:GridView ID="AlbumsList" runat="server" AutoGenerateColumns="False" DataSourceID="AlbumsListODS" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
            <asp:BoundField DataField="ReleaseYear" HeaderText="ReleaseYear" SortExpression="ReleaseYear"></asp:BoundField>
            <asp:BoundField DataField="ReleaseLabel" HeaderText="ReleaseLabel" SortExpression="ReleaseLabel"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="AlbumsListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Albums_ListByYearRelease" TypeName="ChinookSystem.BLL.AlbumController">
        <SelectParameters>
            <asp:ControlParameter ControlID="minYear" PropertyName="Text" Name="minYear" Type="Int32" DefaultValue="1900"></asp:ControlParameter>
            <asp:ControlParameter ControlID="maxYear" PropertyName="Text" Name="maxYear" Type="Int32" DefaultValue="2017"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

