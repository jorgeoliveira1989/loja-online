﻿<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice_top_side.Master" AutoEventWireup="true" CodeBehind="backoffice.aspx.cs" Inherits="loja_online.backoffice2" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  <div id="form1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-success text-white font-weight-bold d-flex justify-content-between">
                        <span>
                            <a href="visualizar_clientes.aspx" class="text-white text-decoration-none d-block mb-2 m-2">
                                <asp:Label ID="lbl_clientes" runat="server" Text="Clientes" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                            </a> 
                        </span>
                        <span>
                            <asp:Label ID="lbl_totalClientesSpan" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        </span>                  
                    </div>
                    <div class="card-body">
                        <div class="mx-auto" style="max-width: 750px;">
                            <asp:Chart ID="Chart1" runat="server" CssClass="img-fluid" Height="450" Width="500" Palette="SeaGreen">
                                <Series>
                                    <asp:Series Name="Series1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-primary text-white font-weight-bold d-flex justify-content-between">
                        <span>
                            <a href="visualizar_clientes.aspx" class="text-white text-decoration-none d-block mb-2 m-2">
                                <asp:Label ID="lbl_revendedores" runat="server" Text="Revendedores" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                            </a> 
                        </span>
                        <span>
                            <asp:Label ID="lbl_totalRevendedoresSpan" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        </span>                  
                    </div>
                    <div class="card-body">
                        <div class="mx-auto" style="max-width: 750px;">
                            <asp:Chart ID="Chart2" runat="server" CssClass="img-fluid" Height="450" Width="500">
                                <Series>
                                    <asp:Series Name="Series1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-danger text-white font-weight-bold d-flex justify-content-between">
                        <span>
                            <a href="visualizar_produtos.aspx" class="text-white text-decoration-none d-block mb-2 m-2">
                                <asp:Label ID="lbl_produtos" runat="server" Text="Produtos" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                            </a> 
                        </span>
                        <span>
                            <asp:Label ID="lbl_totalprodutosspan" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        </span>                  
                    </div>
                    <div class="card-body">
                        <div class="mx-auto" style="max-width: 750px;">
                            <asp:Chart ID="Chart3" runat="server" CssClass="img-fluid" Height="450" Width="500" Palette="None" PaletteCustomColors="Red">
                                <Series>
                                    <asp:Series Name="Series1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                    </div>
                </div>  
            </div>

            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-warning text-white font-weight-bold d-flex justify-content-between">
                        <span>
                            <a href="visualizar_vendas.aspx" class="text-white text-decoration-none d-block mb-2 m-2">
                                <asp:Label ID="lbltotal_encomendas" runat="server" Text="Total de Vendas" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                            </a> 
                        </span>
                        <span>
                            <asp:Label ID="lbl_encomendasspan" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        </span>   
                    </div>
                    <div class="card-body">
                        <div class="mx-auto" style="max-width: 750px;">
                            <asp:Chart ID="Chart4" runat="server" CssClass="img-fluid" Height="450" Width="500" Palette="None" PaletteCustomColors="255, 128, 0">
                                <Series>
                                    <asp:Series Name="Series1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
<br />
    <br />
</div>

</asp:Content>
