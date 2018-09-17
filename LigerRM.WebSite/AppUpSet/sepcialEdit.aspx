<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sepcialEdit.aspx.cs" Inherits="AppUpSet_sepcialEdit" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name="robots" content="all">
    <title>功能页面</title>
    <meta name="keywords" content="">
    <meta name="description" content="">
    <link rel="stylesheet" type="text/css" href="../lib/upload_img/css/ycbootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../lib/upload_img/css/reset.css" />
    <%--    <script src="../lib/upload_img/js/jquery-2.1.3.min.js" type="text/javascript"></script>--%>
    <script src="../lib/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../lib/upload_img/plugins/cover_js/iscroll-zoom.js" type="text/javascript"
        charset="utf-8"></script>
    <script src="../lib/upload_img/plugins/cover_js/hammer.js" type="text/javascript"
        charset="utf-8"></script>
    <script src="../lib/upload_img/plugins/cover_js/lrz.all.bundle.js" type="text/javascript"
        charset="utf-8"></script>
    <script src="../lib/upload_img/plugins/cover_js/jquery.photoClip.min.js" type="text/javascript"
        charset="utf-8"></script>
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-form.css" rel="stylesheet" type="text/css" />
    <script src="../lib/ligerUI/js/core/base.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerForm.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerDateEditor.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerComboBox.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerCheckBox.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerButton.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerRadio.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerSpinner.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerTextBox.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    </script>
</head>
<style type="text/css">
    body
    {
        font-size: 12px;
    }
    .l-table-edit
    {
    }
    .l-table-edit-td
    {
        padding: 4px;
    }
    .l-button-submit, .l-button-reset
    {
        width: 80px;
        float: left;
        margin-left: 10px;
        padding-bottom: 2px;
    }
    .l-verify-tip
    {
        left: 230px;
        top: 120px;
    }
    .inputline
    {
        line-height: normal;
    }
</style>
<body>
    <form name="form1" action="" method="post" id="form1">
    <div>
    </div>
    <input type="hidden" id="SpecialId" value="0" />
    <table cellpadding="0" cellspacing="0" class="l-table-edit">
        <tr>
            <td align="right" class="l-table-edit-td">
                城市特色标题名称：
            </td>
            <td align="left" class="l-table-edit-td">
                <input name="typeName" id="TypeName" type="text" placeholder="请填写该城市特色标题名称" />
            </td>
        </tr>

        <%--元素名字--%>
        <tr>
            <td align="right" class="l-table-edit-td">
                特色中元素名字：
            </td>
            <td align="left" class="l-table-edit-td">
                <input name="Name" id="Name" type="text" placeholder="请填写元素名字" />
            </td>
        </tr>

        <%--省选择--%>
        <tr>
            <td align="right" class="l-table-edit-td">
                请选择省份:
            </td>
            <td align="left" class="l-table-edit-td">
                <select name="provinceid" id="provinceid" style="line-height: normal;">
                    <%=new AppUpSet_sepcialEdit().GetProvince()%>
                </select>
            </td>
            <td align="left">
            </td>
        </tr>
        <%--市选择--%>
        <tr>
            <td align="right" class="l-table-edit-td">
                请选择城市:
            </td>
            <td align="left" class="l-table-edit-td">
                <select name="cityId" id="cityId" style="line-height: normal;">
                </select>
            </td>
            <td align="left">
            </td>
        </tr>
        <%--图片显示的排序--%>
        <tr>
            <td align="right" class="l-table-edit-td">
                App中元素排序:
            </td>
            <td align="left" class="l-table-edit-td">
                <select name="sortId" id="sortId" style="line-height: normal;">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3" selected>3</option>
                </select>
            </td>
            <td align="left">
            </td>
        </tr>
        <%--安卓端App图片占比--%>
        <tr>
            <td align="right" class="l-table-edit-td">
                安卓端App图片占比：
            </td>
            <td align="left" class="l-table-edit-td">
                <input name="imageSize" id="imageSize" type="text" placeholder="填写图片行中占比" />
            </td>
        </tr>
        <%--一句话描述--%>
        <tr>
            <td align="right" class="l-table-edit-td">
                元素描述:
            </td>
            <td align="left" class="l-table-edit-td" colspan="2">
                <textarea cols="100" rows="4" class="l-textarea" name="Describe" id="Describe" style="width: 400px"
                    placeholder="用一句话描述当前元素"></textarea>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="right" class="l-table-edit-td">
                元素图片:
            </td>
            <td align="left" class="l-table-edit-td">
                <div class="cover-wrap" style="display: none; position: fixed; left: 0; top: 0; width: 100%;
                    height: 100%; background: rgba(0, 0, 0, 0.4); z-index: 10000000; text-align: center;">
                    <div class="" style="width: 900px; height: 600px; margin: 100px auto; background-color: #FFFFFF;
                        overflow: hidden; border-radius: 4px;">
                        <div id="clipArea" style="margin: 10px; height: 520px;">
                        </div>
                        <div class="" style="height: 56px; line-height: 36px; text-align: center; padding-top: 8px;">
                            <input id="clipBtn" style="width: 120px; height: 36px; border-radius: 4px; background-color: #ff8a00;
                                color: #FFFFFF; font-size: 14px; text-align: center; line-height: 36px; outline: none;"
                                value="保存" />
                        </div>
                    </div>
                </div>
                <div id="view" style="width: 214px; height: 160.5px;" title="请上传 428*321 的元素图片">
                </div>
                <div style="height: 10px;">
                </div>
                <div class="" style="width: 140px; height: 32px; border-radius: 4px; background-color: #ff8a00;
                    color: #FFFFFF; font-size: 14px; text-align: center; line-height: 32px; outline: none;
                    margin-left: 37px; position: relative;">
                    点击上传图片
                    <input type="file" id="file" style="cursor: pointer; opacity: 0; filter: alpha(opacity=0);
                        width: 100%; height: 100%; position: absolute; top: 0; left: 0;">
                </div>
                <input type="hidden" id="ImageUrl" />
            </td>
            <td align="left">
            </td>
        </tr>
    </table>
    <br />
    <input type="button" value="提交" id="submit" style="width: 100px; height: 35px;" />
    </form>
</body>
</html>
<script src="../AppUpSetJS/sepcialEdit.js?54545" type="text/javascript"></script>
