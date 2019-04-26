

function CalisanSil(ID) {
    if (confirm("silmek istediğinizden için emin misiniz?")) {
        $.ajax({
            type: "POST",
            url: "/AdminUI/Calisan/AjaxDeleteCalisan",


            data: "id=" + ID,
            cache: false,
            success: function (data) {
                if (data == 1) {
                    $("#CalisanList_" + ID).css("display", "none");
                }
                else {
                    alert("Problem mevcut. silinmedi");
                }
            }
        });
    }

}


function DepartmanSil(ID) {
    if (confirm("silmek istediğinizden için emin misiniz?")) {
        $.ajax({
            type: "POST",
            url: "/AdminUI/Departman/AjaxDeleteDepartman",
            data: "id=" + ID,
            cache: false,
            success: function (data) {
                if (data == 1) {
                    $("#DepartmanList_" + ID).css("display", "none");
                }
                else {
                    alert("Problem mevcut. silinmedi");
                }
            }
        });
    }

}



