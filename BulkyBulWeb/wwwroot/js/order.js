﻿var dataTable;
$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else {
        if (url.includes("completed")) {
            loadDataTable("completed");
        }
        else {
            if (url.includes("pending")) {
                loadDataTable("pending");
            }
            else {
                if (url.includes("approved")) {
                    loadDataTable("approved");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },
        "columns": [
            { "data": "id","width": "5%" },
            { "data": "name","width": "25%" },
            { "data": "phoneNumber","width": "10%" },
            { "data": "applicationUser.email", "width": "10%" },
            { "data": "orderStatus", "width": "10%" },
            { "data": "orderTotal", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="container" role="group">
                        <a href="/Admin/Order/Details?orderId=${data}" 
                        class="btn btn-primary offset-2" ><i class="bi bi-pencil-square"></i>Details</a>
                       
                    </div>
                `
                }, 
                "width": "15%"
            }, 
        ],
    })
}

