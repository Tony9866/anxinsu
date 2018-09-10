var nFileCount = 0;
var bAdjustMode = 0;
var bCropArea = 0;
var bSeriesCapture = 0;
var bReadBarCode = 0;
var bSetDenoise = 0;
var Width = 0;
var Height = 0;
var strFile;
var index = 0;
var strCardFile;
var cardIndex = 0;
function Capture(file) {
    var filename = file || "d:\\FileOutput.bmp"
    CmCaptureOcx.CaptureImage(filename);
}
function Adjust() {
    if (bAdjustMode == 0) {
        CmCaptureOcx.AutoCrop(1);
        bAdjustMode = 1;
    }
    else {
        CmCaptureOcx.AutoCrop(0);
        bAdjustMode = 0;
    }
}
function SetCropArea() {
    if (bCropArea == 0) {
        bCropArea = 1;
        CmCaptureOcx.CusCrop(bCropArea);
    }
    else {
        bCropArea = 0;
        CmCaptureOcx.CusCrop(bCropArea);
    }
}
function UpdataFile() {

    var Url = "http://localhost:19890/WebSite1/WebService.asmx/HelloWorld?cmd1=cmd1";
    CmCaptureOcx.UpdataFile(Url, strFile, 0);
}
function Preview() {
    CmCaptureOcx.PreviewFile(strFile);
}

function SetResolution() {
    var obj = document.getElementById("Resolution");
    var index = obj.selectedIndex;
    CmCaptureOcx.SetResolution(index);
}

function StartVideoRecord() {
    var path = "d:\\test\\1.wmv"
    CmCaptureOcx.StartVideo(path, 1);
}

function SeriesCapture() {
    var path = "d:\\test\\自动连拍\\";
    CmCaptureOcx.SeriesCapture(1, path);
}

function ReadBarCode() {
    if (bReadBarCode == 0) {
        bReadBarCode = 1;
        CmCaptureOcx.ReadBarCode(bReadBarCode);
    }
    else {
        bReadBarCode = 0;
        CmCaptureOcx.ReadBarCode(bReadBarCode);
    }
}

function DeleteFile() {
    CmCaptureOcx.DeleteFile(strFile);
}

function GetDevSN() {
    var strSN = CmCaptureOcx.GetDevSN(0);
}

function SetDenoise() {
    if (bSetDenoise == 0) {
        bSetDenoise = 1;
        CmCaptureOcx.SetDenoise(bSetDenoise);
    }
    else {
        bSetDenoise = 0;
        CmCaptureOcx.SetDenoise(bSetDenoise);
    }
}

function SetFileType() {
    var obj = document.getElementById("FileType");
    var index = obj.selectedIndex;
    CmCaptureOcx.SetFileType(index);
}

function SetImageColorMode() {
    var obj = document.getElementById("ColourMode");
    var index = obj.selectedIndex;
    CmCaptureOcx.SetImageColorMode(index);
}

function StartVideo() {
    CmCaptureOcx.Initial();
    CmCaptureOcx.StartRun(index);
    //	AddResolution2Comb(Reso);
    //	SetResolution();
    SetFileType();
}

function AddResolution2Comb(f) {
    var i = 0;
    var total = CmCaptureOcx.GetResolutionCount();
    for (i = 0; i < total; i++) {
        var resolution = CmCaptureOcx.GetResolution(i);
        f.Resolution.options[i].text = resolution;
    }
}

function ChangeDevice() {
    var obj = document.getElementById("DeviceName");
    index = obj.selectedIndex;
    CmCaptureOcx.StartRun(index);
    AddResolution2Comb(Reso);
    SetResolution();
}

function SetPicMark() {
    CmCaptureOcx.SetMarkPic("C:\\1.jpg");
}

function AddDevice() {
    var i = 0;
    var total = CmCaptureOcx.GetDevCount();
    for (i = 0; i < total; i++) {
        var DevEle = CmCaptureOcx.GetDevFriendName(i);
        Reso.DeviceName.options[i].text = DevEle;
    }
}

function Sleep(seconds) {
    var d1 = new Date();
    var t1 = d1.getTime();
    for (; ; ) {
        var d2 = new Date();
        var t2 = d2.getTime();
        if (t2 - t1 > seconds * 1000) {
            break;
        }
    }
}

function Test() {
    strCardFile = "d:\\test\\cardImage" + cardIndex;
    strCardFile += ".jpg";
    CmCaptureOcx.CaptureImage(strCardFile);
    if (cardIndex == 0) {
        cardIndex = 1;
    }
    else {
        CmCaptureOcx.CombineTwoImage("d:\\test\\cardImage.jpg", "d:\\test\\cardImage0.jpg", "d:\\test\\cardImage1.jpg", 1);
        cardIndex = 0;
    }

}

function ConvertToPDF(file) {
    var pdfFileName = file || "d:\\FilePdf.pdf"
    CmCaptureOcx.Convert2PDF(pdfFileName, 0);
}
