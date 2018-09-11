$(function () {
    var BannerId = GetQueryString("BannerId");
    //判断BannerId是否有值
    if (typeof (obj) == "BannerId") {
        GetMod(BannerId);
    }

    $("form").ligerForm();


    $("[name='InnerChain']").hide();
    $("[name='OuterChain']").hide();
    $(document).on("change", "[name='BannerType']", function () {
        var html = "";

        if ($(this).val() == "3") {
            $("[name='InnerChain']").hide();
            $("[name='OuterChain']").hide();
            //无链接
        } else if ($(this).val() == "2") {
            //内链
            $("[name='InnerChain']").show();
            $("[name='OuterChain']").hide();
            $("#InnerChain_fy").hide();
        } else if ($(this).val() == "1") {
            //外链
            $("[name='InnerChain']").hide();
            $("[name='OuterChain']").show();
        }
    })

    $(document).on("change", "#InnerChainType", function () {
        if ($(this).val() == "1") {
            $("#InnerChain_fyfl").show();
            $("#InnerChain_fy").hide();
            //无链接
        } else {
            $("#InnerChain_fyfl").hide();
            $("#InnerChain_fy").show();
        }

    })

    $("#Class").ligerGetComboBoxManager().clearContent();
    var data = [{ id: 1, name: "桔子" }, { id: 2, name: "苹果" }, { id: 1, name: "梨子"}];
    var fruitManager = $("#Class").ligerComboBox({
        data: data,
        isMultiSelect: true,
        selectBoxWidth: 150,
        width: 150,
        selectBoxHeight: 155,
        isShowCheckBox: true,
        initText: '请选择',
        valueFieldID: 'fruitList',
        valueField: 'id',
        textField: 'name'
    });
    liger.get("Class").setData(data);

    $(document).on("click", "#submit", function () {
        var BannerType = $("#BannerType").val(); //轮播图类型
        var ImageUrl = $("#ImageUrl").val(); //轮播图图片
        var Url = $("#Url").val(); //外链地址url
        var Describe = $("#Describe").val(); //描述
        var InnerChainType = $("#InnerChainType").val(); //内链类型
        var Class = $("#Class").val(); //内链-分类ID
        var RentNO = $("#RentNO").val(); //内链-房屋详情

        var JsonMod = {};
        JsonMod.BannerType = BannerType;
        JsonMod.ImageUrl = ImageUrl;
        JsonMod.Url = Url;
        JsonMod.Describe = Describe;
        JsonMod.innerClassId = InnerChainType;
        if (InnerChainType == "1") {
            JsonMod.innerContent = Class;
        } else {
            JsonMod.innerContent = RentNO;
        }


        $.ajax({
            cache: false,
            async: false,
            type: 'post',
            dataType: 'json',
            data: { "type": "GetHousing", "data": JSON.stringify(JsonMod) },
            url: "/AppUpSetAshx/ajax.ashx",
            success: function (data) {
                if (data.Code == "0") {
                    alert(data.Msg);
                    window.close();
                } else {
                    alert(data.Msg);
                }
            }
        });


    })
})



//上传封面
//document.addEventListener('touchmove', function (e) { e.preventDefault(); }, false);
var clipArea = new bjj.PhotoClip("#clipArea", {
    size: [100, 50], // 截取框的宽和高组成的数组。默认值为[260,260]
    outputSize: [428, 321], // 输出图像的宽和高组成的数组。默认值为[0,0]，表示输出图像原始大小
    //outputType: "jpg", // 指定输出图片的类型，可选 "jpg" 和 "png" 两种种类型，默认为 "jpg"
    file: "#file", // 上传图片的<input type="file">控件的选择器或者DOM对象
    view: "#view", // 显示截取后图像的容器的选择器或者DOM对象
    ok: "#clipBtn", // 确认截图按钮的选择器或者DOM对象
    loadStart: function () {
        // 开始加载的回调函数。this指向 fileReader 对象，并将正在加载的 file 对象作为参数传入
        $('.cover-wrap').fadeIn();
        console.log("照片读取中");
    },
    loadComplete: function () {
        // 加载完成的回调函数。this指向图片对象，并将图片地址作为参数传入
        console.log("照片读取完成");
    },
    //loadError: function(event) {}, // 加载失败的回调函数。this指向 fileReader 对象，并将错误事件的 event 对象作为参数传入
    clipFinish: function (dataURL) {
        $("#ImageUrl").val(dataURL);
        // 裁剪完成的回调函数。this指向图片对象，会将裁剪出的图像数据DataURL作为参数传入
        $('.cover-wrap').fadeOut();
        $('#view').css('background-size', '100% 100%');
        //        console.log(dataURL);
    }
});



function GetMod(BannerId) {


    $.ajax({
        cache: false,
        async: false,
        type: 'post',
        dataType: 'json',
        data: { "type": "GetHousing", "data": JSON.stringify(JsonMod) },
        url: "/AppUpSetAshx/ajax.ashx",
        success: function (data) {
            if (data.Code == "0") {
                alert(data.Msg);
                window.close();
            } else {
                alert(data.Msg);
            }
        }
    });

}


//获取参数
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return decodeURI(r[2]);
    return null;
}