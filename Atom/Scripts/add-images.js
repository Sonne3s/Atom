﻿var data = [];//new FormData();//массив для загрузки на сервер
var imgArray = [];//массив с загруженными изображениями вида: name - value
        function processData(data)//функия добавления изображений после использования асинхронного запроса
        {
        //alert("куre");
    var target = $("#ajax");
            target.empty();
            target.append("<img src=" + data[0] + " />")
        }
    //$("body").on('dragenter', function (e) {e.preventDefault(); $("#add-effect").addClass("hover"); })
    //$("body").on('dragleave', function (e) {e.preventDefault(); $("#add-effect").removeClass("hover"); })
    //$("body").on('dragover', function (e) {e.preventDefault(); $("#add-effect").addClass("hover"); });//рамка при перетаскивании файла
        $("input[name~='sub']").on("click", function (e) {
            upload(data.shift());
        })
        $("body").on('drop', function (e) {
        e.preventDefault();
    e.dataTransfer = e.originalEvent.dataTransfer;
        var files = e.dataTransfer.files;

        if (files.length > 0)
        {
        LoadInView(files);
    }
        });

    function LoadInView(files) {//загрузка перетянутых файлов в массив
        var err = 0;//счетчик не изображений
        $.each(files, function (i, val) {//проверка на изображения
            if (!val.type.match('image.*')) {
        alert('файл не является изображением');
    err++;
            }
            else {
                data.push({ index: i, value: val });
                var fileReader = new FileReader();//обработчик файлов
                //событие после обработки
                fileReader.onload=(function (file){
                    return function (e) {
        imgArray.push({ name: i, value: this.result });//добавляет результат обработки в массив изобажений
    ViewImg(imgArray);//если вызвать не здесь, то в массив еще не будет добавлено
                    };
                })(files[i]);
                fileReader.readAsDataURL(val);//добавление изображения в массив
            }
        });
        alert(err);
        if (err === 0) alert("все ок");
        }
    function hidden() {
        $("#hidden-button").on("click", function () {
            $(this).val("развернуть");
            var container = $("#ajax");
            var containerhidden = $("#ajax-hidden");
            var id = container.attr("id");
            if (id==="ajax")
            {
                container.attr("id", "ajax-hidden");
                $(this).val("развернуть");
            }
            else
            {
                containerhidden.attr("id", "ajax");
                $(this).val("свернуть");
            }
        });        
    }
    function ViewImg(images)
    {
        var container = $("#ajax");
        container.empty();
        container.append("<div class='row'><div class='col-md-12'><input type='button' value='свернуть' class='btn btn-block' style='position:fixed; z-index:1200; margin-left:-15px;' id='hidden-button'/></div></div");
        $("#ajax .row").append("<div class='col-md-3 override-padding'><div class='thumbnail override-padding'><div class='img'>"
            + "<label class='btn-block' style='padding:90px; text-align:center;'><span class='glyphicon glyphicon-plus' style='font-size:xx-large;'></span >"
            + "<input type='file' name='images' id='uploadbtn' multiple='multiple' class='btn btn-default btn-block' style='display:none;'"
            + "</label></div><p>. </p></div></div>")
        $.each(images, function (i, val) {
            //alert($("#iid"));
            $("#ajax .row").append("<div class='col-md-3 override-padding'><div class='thumbnail override-padding'><div class='img'><img id='img" + i + "' src='" + images[i].value + "' class='img-responsive' /></div><p>"+images[i].name+"</p></div></div>");
        });
        //тест отправки
        //container.append("<input type='button' value='Тест' name='test'/>");
        //$("input[name~='test']").on("click", function (e) {
        //    if ($("input[name~='imgStartIndex']").val() != "") alert("fghgf");
        //    upload(data.shift());
        //});
        hidden();
    }
    function upload(sendData)
    {
        if (!!sendData)
        {
            alert(!!sendData);
            var d = new FormData();
            d.append(sendData.index, sendData.value, sendData.index);
            d.append("theme", $("input[name~='Name']").val());
            $.ajax({
                type: "POST",
                url: "CreateJsonPicturesPost",//getUrl(),
                contentType: false,
                processData: false,
                data: d,
                success: successedPict,
                error: false
            });
        }
        else
        {
            successedPict(0);
        }
        return false;
    }
    function successedPict(answer)
    {
        if (data.length > 0)
        {
            upload(data.shift());
            if ($("input[name~='imgStartIndex']").val() === "") $("input[name~='imgStartIndex']").val(answer);
        }
        else {
            if ($("input[name~='imgStartIndex']").val() === "") $("input[name~='imgStartIndex']").val(answer);
            var target = $("#ajax");
            target.empty();
            target.append("<p>" + answer + " " + data.length +"</p>");
            $("#form").submit();
        }
    }