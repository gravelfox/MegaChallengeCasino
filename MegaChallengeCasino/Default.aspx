<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="reel1" runat="server" Height="150px" Width="150px" />
        <asp:Image ID="reel2" runat="server" Height="150px" Width="150px" />
        <asp:Image ID="reel3" runat="server" Height="150px" Width="150px" />
    
    </div>
        <p>
            Your Bet:
            <asp:TextBox ID="wagerBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="spinButton" runat="server" Text="Pull the Lever!" OnClick="spinButton_Click" />
        </p>
        <p>
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </p>
        <p>
            Player&#39;s Money:
            <asp:Label ID="moneyLabel" runat="server"></asp:Label>
        </p>
    </form>
    <p>
        1 Cherry - x2 Your Bet<br />
        2 Cherries - x3 Your Bet<br />
        3 Cherries - x4 Your Bet<br />
        3 7&#39;s - JACKPOT - x100 Your Bet<br />
        HOWEVER... if there&#39;s even one BAR you win nothing.</p>
</body>
</html>
