$("input[name~='Tags']").change(function () {
    var tags = $("input[name~='Tags']").val().split(/#/i);
    var output = "";
    tags.forEach(function (item, i, tags) {
        if(i>0)output += "<span class='glyphicon glyphicon-remove' style='color:red;'></span>"+item.trim()+" ";
    });
    alert(output);
    $("input[name~='Tags']").html(output);
})