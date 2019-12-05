/////////////////////////
var swfu;
var swfu_totalFileSize = 0;
var swfu_completedSize = 0;
var swfu_totalPercentage = "0%";
var swfu_totalUploadedSize = 0;
var swfu_k_size = 1024;
var swfu_m_size = swfu_k_size * 1024;
var swfu_errorFileCount = 0;

function fileQueueError(file, errorCode, message) {

    try {
        //        var errorName = "";
        //        if (errorCode === SWFUpload.errorCode_QUEUE_LIMIT_EXCEEDED) {
        //            errorName = "You have attempted to queue too many files.";
        //        }
        //        
        //        if (errorName !== "") {
        //            alert(errorName);
        //            return;
        //        }

        switch (errorCode) {
            case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
                swfu_errorFileCount++;
                alert("The selected file size is 0 bytes. Please select another one.");
                break;
            case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
                swfu_errorFileCount++;
                alert("The selected file size is over 300M bytes. Please use the WiSync client application upload it.");
                break;
            //            case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:   
            //            case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:   
            default:

                //alert(message);
                break;
        }

    } catch (ex) {
        this.debug(ex);
    }
}

function fileQueued(file) {

    this.fileProgressID = "divFileProgress";

    this.fileProgressWrapper = document.getElementById(this.fileProgressID);

    if (!this.fileProgressWrapper) {

        $("#" + this.customSettings.progress_target).append('<table id="' + this.fileProgressID + '"></table>');
        this.fileProgressWrapper = document.getElementById(this.fileProgressID);
        $("#" + this.fileProgressID)
                .attr("width", "450px")
                .attr("border", "0")
                .attr("align", "center")
                .attr("cellpadding", "0")
                .attr("cellspaceing", "0")
                .attr("class", "sheet1");
    }

    $("#" + this.fileProgressID).append("<tr id='" + file.id + "'></tr>");

    $("#" + file.id).append('<td  height="24" align="right" ><p style="width:21px">' + (file.index + 1 - swfu_errorFileCount) + '.<p></td>');

    $("#" + file.id).append('<td></td>');
    $("#" + file.id).find("td:eq(1)").append('<div class="loading left"></div>');

    $("#" + file.id).find("td:eq(1)").find("div").append('<div class="loading_bg"></div>');

    $("#" + file.id).find("td:eq(1)").find("div").find("div").append('<div class="loading_time"></div>');
    var temp = file.name.length > 28 ? (file.name.substring(0, 28) + "...") : file.name;
    var html = "<span class='progress_l'>" + temp + " 0% 0K of " + formatFileSize(file.size) + "</span>";
    $("#" + file.id).find("td:eq(1)").find("div").find("div").find("div").append(html);
    html = "<span class='progress_r'></span>";
    $("#" + file.id).find("td:eq(1)").find("div").find("div").find("div").append(html);
    $("#" + file.id).append('<td align="left" ><img src="../App_Themes/DefaultTheme/images/icon_Delete-a-file.png" /></td>');

    var swfuploadInstance = this;
    $("#" + file.id).find("img").click(function () {
        swfuploadInstance.cancelUpload(file.id, true);
    }).css("cursor", "pointer");
    swfu_totalFileSize += file.size;

}

function fileDialogComplete(numFilesSelected, numFilesQueued) {
    try {
        if (numFilesQueued > 0) {
            var folderId = GetCurFolderId();
            var userEmail = $("#email").val();
            var userPswd = $("#pswd").val();
            swfu.setPostParams({
                //"ASPSESSID": "<%=Session.SessionID %>",
                "folderId": folderId,
                "email": userEmail,
                "pswd": userPswd
            });
            this.startUpload();
        }
    } catch (ex) {
        this.debug(ex);
    }
}

function uploadProgress(file, bytesLoaded) {

    try {
        var percent = Math.ceil((bytesLoaded / file.size) * 100);
        var progress = new FileProgress(file, this.customSettings.upload_target);
        progress.setProgress(percent, file, bytesLoaded);
        if (percent === 100) {
            progress.setStatus("Finished", file);
            progress.toggleCancel(false, this, file.id);
        } else {
            progress.toggleCancel(true, this, file.id);
        }
    } catch (ex) {
        this.debug(ex);
    }
}

function uploadSuccess(file, serverData) {
    try {
        var progress = new FileProgress(file, this.customSettings.upload_target);
        progress.setSuccess(file);
        progress.toggleCancel(false);
        swfu_completedSize += file.size;
    } catch (ex) {
        this.debug(ex);
    }
}

function uploadComplete(file) {
    try {
        if (this.getStats().files_queued > 0) {
            this.startUpload();
        } else {
            var progress = new FileProgress(file, this.customSettings.upload_target);
            progress.setComplete(file);
            progress.toggleCancel(false);
        }
    } catch (ex) {
        this.debug(ex);
    }
}

function uploadError(file, errorCode, message) {
    var progress;
    try {
        switch (errorCode) {
            case SWFUpload.UPLOAD_ERROR.FILE_CANCELLED:
                try {
                    progress = new FileProgress(file, this.customSettings.upload_target);
                    progress.setCancelled(file);
                    progress.setStatus("Cancelled", file);
                    progress.toggleCancel(false);
                }
                catch (ex1) {
                    this.debug(ex1);
                }
                break;
            case SWFUpload.UPLOAD_ERROR.UPLOAD_STOPPED:
                try {
                    progress = new FileProgress(file, this.customSettings.upload_target);
                    progress.setCancelled(file);
                    progress.setStatus("Stopped", file);
                    progress.toggleCancel(true);
                }
                catch (ex2) {
                    this.debug(ex2);
                }
            case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
                progress = new FileProgress(file, this.customSettings.upload_target);
                progress.setStatus("Failed", file);
                progress.toggleCancel(false);
                break;
            default:
                progress = new FileProgress(file, this.customSettings.upload_target);
                progress.setStatus("Failed", file);
                progress.toggleCancel(false);
                //alert(message);
                break;
        }

    } catch (ex3) {
        this.debug(ex3);
    }

}

/* ******************************************
*	FileProgress Object
*	Control object for displaying file info
* ****************************************** */

function FileProgress(file, targetID) {
    this.fileProgressID = "divFileProgress";

    this.fileProgressWrapper = document.getElementById(this.fileProgressID);

    if (!this.fileProgressWrapper) {
        $("#" + this.customSettings.progress_target).append("<table id='" + this.fileProgressID + "'></table>");
        this.fileProgressWrapper = document.getElementById(this.fileProgressID);
        $("#" + this.fileProgressID).attr("width", "100%").attr("border", "0").attr("align", "center").attr("cellpadding", "0").attr("cellspaceing", "0").attr("class", "sheet1");
    } else {
        this.fileProgressElement = document.getElementById(file.id);
    }
}

function formatFileSize(bytes) {
    var str = "";
    if (bytes > swfu_m_size) {
        str = Math.round(bytes * 100 / swfu_m_size) / 100 + "M";
    }
    else if (bytes > swfu_k_size) {
        str = Math.round(bytes * 100 / swfu_k_size) / 100 + "K";
    } else {
        str = bytes + "B";
    }
    return str;
}

FileProgress.prototype.setProgress = function (percentage, file, bytesLoaded) {
    this.fileProgressElement;

    var rowId = "#" + file.id;
    var filename = file.name.length > 20 ? (file.name.substring(0, 20) + "...") : file.name;
    var spanText = filename + " " + percentage + "% " + formatFileSize(bytesLoaded) + " of " + formatFileSize(file.size);
    var html = $(rowId).html();
    html = $(rowId).find("span:eq(0)").text();
    $(rowId).find("span:eq(0)").text(spanText);
    html = $(rowId).find("span:eq(0)").html();
    $(rowId).find("td:eq(1)").find("div").find("div").find("div").css("width", percentage + "%");


    swfu_totalUploadedSize = swfu_completedSize + bytesLoaded; //当前已经完成的文件大小+当前正在上传文件已经上传的大小
    swfu_totalPercentage = Math.round((swfu_totalUploadedSize * 100) / swfu_totalFileSize) + "%";

    $("#totalProgressBarText").text(filename + " " + swfu_totalPercentage + " " + formatFileSize(swfu_totalUploadedSize) + " of " + formatFileSize(swfu_totalFileSize));

    $("#totalUploadingProgress").css("width", swfu_totalPercentage);
};
FileProgress.prototype.setComplete = function (file) {
    GetFileList(GetCurFolderId(), $("#email").val(), $("#pswd").val());
    $("#demo_table2").hide("slow");
    $("#greybackground").remove();
    //    if (swfu_totalFileSize != 0) {
    //        $("#totalProgressBarDiv").css("display", "block");
    //    }
    $("#totalProgressBarDiv").css("display", "none");
};
FileProgress.prototype.setSuccess = function (file) {
    var rowId = "#" + file.id;
    $(rowId).find("td:eq(2)").empty();
    $(rowId).find("td:eq(2)").html("Finished");
};
FileProgress.prototype.setError = function (file) {
    var rowId = "#" + file.id;
    $(rowId).find("td:eq(2)").empty();
    $(rowId).find("td:eq(2)").html("Error");
};
FileProgress.prototype.setCancelled = function (file) {
    var rowId = "#" + file.id;
    $(rowId).nextAll("tr").each(function () {
        var index = $(this).find("td:eq(0)").find("p").text();
        index = index.substr(0, index.length - 1);
        index = index- 1;
        index = index + ".";
        $(this).find("td:eq(0)").find("p").text(index);
    }); ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //此处有问题
    //    $(rowId).find("td:eq(2)").empty();
    //    $(rowId).find("td:eq(2)").html("Cancelled");
    $(rowId).hide();
    swfu_errorFileCount++;
    swfu_totalUploadedSize = swfu_completedSize; //取消的文件大小在总的上传大小中被排除
    swfu_totalFileSize -= file.size;

    //更新上传进度条的显示
    swfu_totalPercentage = Math.round((swfu_totalUploadedSize * 100) / swfu_totalFileSize) + "%";

    $("#totalProgressBarText").text(filename + " " + swfu_totalPercentage + " " + formatFileSize(swfu_totalUploadedSize) + " of " + formatFileSize(swfu_totalFileSize));

    $("#totalUploadingProgress").css("width", swfu_totalPercentage);
};
FileProgress.prototype.setStatus = function (status, file) {
    var rowId = "#" + file.id;
    $(rowId).find("td:eq(2)").empty();
    $(rowId).find("td:eq(2)").html(status);
};

FileProgress.prototype.toggleCancel = function (show, swfuploadInstance, fileId) {
    $("#" + fileId).find("img").unbind("click");
    if (show) {
        if (swfuploadInstance) {
            $("#" + fileId).find("img").click(function () {
                swfuploadInstance.cancelUpload(fileId, true);
            });
        }
    }
};