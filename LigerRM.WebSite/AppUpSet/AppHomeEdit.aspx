<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppHomeEdit.aspx.cs" Inherits="AppUpSet_AppHomeEdit" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name="robots" content="all">
    <title>上传图片，可调图片宽高</title>
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
    <input type="hidden" id="BannerId" value="0" />
    <table cellpadding="0" cellspacing="0" class="l-table-edit">
        <tr>
            <td align="right" class="l-table-edit-td">
                轮播图类型:
            </td>
            <td align="left" class="l-table-edit-td">
                <select name="BannerType" id="BannerType" ltype="BannerType" style="line-height: normal;">
                    <option value="3">无链接</option>
                    <option value="2">内链</option>
                    <option value="1">外联</option>
                </select>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr name="InnerChain">
            <td align="right" class="l-table-edit-td">
                内链类型:
            </td>
            <td align="left" class="l-table-edit-td">
                <select name="InnerChainType" id="InnerChainType" ltype="select">
                    <option value="1">房源分类</option>
                    <option value="2">房源</option>
                </select>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr name="InnerChain" id="InnerChain_fyfl">
            <td align="right" class="l-table-edit-td">
                房屋分类
            </td>
            <td align="left" class="l-table-edit-td">
                <select name="Class" id="Class" ltype="Class">
                    <%=new AppUpSet_AppHomeEdit().GetHousing() %>
                </select>
            </td>
        </tr>
        <tr name="InnerChain" id="InnerChain_fy">
            <td align="right" class="l-table-edit-td">
                房屋编号
            </td>
            <td align="left" class="l-table-edit-td">
                <input name="RentNO" type="text" id="RentNO" class="l-text-field" style="width: 174px;" />
            </td>
        </tr>
        <tr name="OuterChain">
            <td align="right" class="l-table-edit-td">
                外联地址
            </td>
            <td align="left" class="l-table-edit-td">
                <input name="Url" id="Url" type="text" ltype="text" />
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="right" class="l-table-edit-td">
                轮播图:
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
                <div id="view" style="width: 214px; height: 160.5px;" title="请上传 428*321 的封面图片">
                </div>
                <div style="height: 10px;">
                </div>
                <div class="" style="width: 140px; height: 32px; border-radius: 4px; background-color: #ff8a00;
                    color: #FFFFFF; font-size: 14px; text-align: center; line-height: 32px; outline: none;
                    margin-left: 37px; position: relative;">
                    点击上传封面图
                    <input type="file" id="file" style="cursor: pointer; opacity: 0; filter: alpha(opacity=0);
                        width: 100%; height: 100%; position: absolute; top: 0; left: 0;">
                </div>
                <input type="hidden" id="ImageUrl" />
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="right" class="l-table-edit-td">
                描述:
            </td>
            <td align="left" class="l-table-edit-td" colspan="2">
                <textarea cols="100" rows="4" class="l-textarea" name="Describe" id="Describe" style="width: 400px"></textarea>
            </td>
            <td align="left">
            </td>
        </tr>
    </table>
    <br />
    <input type="button" value="提交" id="submit" style="width: 100px; height: 35px;" />
    </form>
    <script type="text/javascript">


        //clipArea.destroy();
    </script>
    <script type="text/javascript">
        $(function () {
//            $("form").ligerForm();
        }); 

    </script>
</body>
</html>
<script src="../AppUpSetJS/AppHomeEdit.js?232323" type="text/javascript"></script>
