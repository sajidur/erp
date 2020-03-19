<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="RexERP_MVC.Report.Viewer.ReportViewer" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Page</title>
    <script type="text/javascript" src="../../Scripts/jquery-3.1.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">        
    <asp:ScriptManager ID="ScriptManager1" runat="server" ValidateRequestMode="Disabled" AsyncPostBackTimeout="3600" EnablePartialRendering="true" ></asp:ScriptManager>
   <script type="text/javascript" language="javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    function EndRequestHandler(sender, args){
        if (args.get_error() != undefined){
            args.set_errorHandled(true);
        }
    }
</script>
         <div style="height: 252px">
        <asp:Label ID="lblMsg" runat="server" Text=""  Font-Size="20px" ForeColor="Red"></asp:Label>
      <button id="printreport">Print</button>
          <asp:Button ID="btnTruckChallan" runat="server" OnClick="btnTruckChallan_Click" Text="Print Truck Challan" Visible="False" />
          <br />
         <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        InteractiveDeviceInfos="(Collection)" ProcessingMode="Remote" WaitMessageFont-Names="Verdana"
        WaitMessageFont-Size="14pt" ShowPrintButton="true" ShowExportControls="true" Width="1280px" Height="700px"
        ShowBackButton="true" ShowToolBar="true" ShowParameterPrompts="true" ShowPageNavigationControls="true"
        ZoomMode="Percent" ZoomPercent="100" ShowReportBody="true" InternalBorderStyle="Solid">
    </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $('#printreport').click(function () {
        printReport('ReportViewer1');
    });
    // Print function (require the reportviewer client ID)
    function printReport(report_ID) {
        var rv1 = $('#' + report_ID);
        var iDoc = rv1.parents('html');

        // Reading the report styles
        var styles = iDoc.find("head style[id$='ReportControl_styles']").html();
        if ((styles == undefined) || (styles == '')) {
            iDoc.find('head script').each(function () {
                var cnt = $(this).html();
                var p1 = cnt.indexOf('ReportStyles":"');
                if (p1 > 0) {
                    p1 += 15;
                    var p2 = cnt.indexOf('"', p1);
                    styles = cnt.substr(p1, p2 - p1);
                }
            });
        }
        if (styles == '') { alert("Cannot generate styles, Displaying without styles.."); }
        styles = '<style type="text/css">' + styles + "</style>";

        // Reading the report html
        var table = rv1.find("div[id$='_oReportDiv']");
        if (table == undefined) {
            alert("Report source not found.");
            return;
        }

        // Generating a copy of the report in a new window
        var docType = '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/loose.dtd">';
        var docCnt = styles + table.parent().html();
        var docHead = '<head><title>Printing ...</title><style>body{margin:5;padding:0;}</style></head>';
        var winAttr = "location=yes, statusbar=no, directories=no, menubar=no, titlebar=no, toolbar=no, dependent=no, width=720, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";;
        var newWin = window.open("", "_blank", winAttr);
        writeDoc = newWin.document;
        writeDoc.open();
        writeDoc.write(docType + '<html>' + docHead + '<body onload="window.print();">' + docCnt + '</body></html>');
        writeDoc.close();

        // The print event will fire as soon as the window loads
        newWin.focus();
        // uncomment to autoclose the preview window when printing is confirmed or canceled.
        // newWin.close();
    };

    $(document).ready(function () {
        if ($.browser.mozilla) {
            try {
                var ControlName = 'ReportViewer1';
                var innerScript = '<scr' + 'ipt type="text/javascript">document.getElementById("' + ControlName + '_print").Controller = new ReportViewerHoverButton("' + ControlName + '_print", false, "", "", "", "#ECE9D8", "#DDEEF7", "#99BBE2", "1px #ECE9D8 Solid", "1px #336699 Solid", "1px #336699 Solid");</scr' + 'ipt>';
                var innerTbody = '<tbody><tr><td><input type="image" style="border-width: 0px; padding: 2px; height: 16px; width: 16px;" alt="Print" src="/Reserved.ReportViewerWebControl.axd?OpType=Resource&amp;Version=9.0.30729.1&amp;Name=Microsoft.Reporting.WebForms.Icons.Print.gif" title="Print"></td></tr></tbody>';
                var innerTable = '<table title="Print" onmouseout="this.Controller.OnNormal();" onmouseover="this.Controller.OnHover();" onclick="PrintFunc(\'' + ControlName + '\'); return false;" id="' + ControlName + '_print" style="border: 1px solid rgb(236, 233, 216); background-color: rgb(236, 233, 216); cursor: default;">' + innerScript + innerTbody + '</table>'
                var outerScript = '<scr' + 'ipt type="text/javascript">document.getElementById("' + ControlName + '_print").Controller.OnNormal();</scr' + 'ipt>';
                var outerDiv = '<div style="display: inline; font-size: 8pt; height: 30px;" class=" "><table cellspacing="0" cellpadding="0" style="display: inline;"><tbody><tr><td height="28px">' + innerTable + outerScript + '</td></tr></tbody></table></div>';

                $("#" + ControlName + " > div > div").append(outerDiv);

            }
            catch (e) { alert(e); }
        }
    });

    function PrintFunc(ControlName) {
        setTimeout('ReportFrame' + ControlName + '.print();', 100);
    }
</script>