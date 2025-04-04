﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/company/getall",
            "type": "GET", 
            "datatype": "json" 
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "streetAddress", "width": "15%" },
            { "data": "city", "width": "10%" },
            { "data": "state", "width": "15%" },
            { "data": "phoneNumber", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="btn-group w-75" role="group">
                            <a href="/Admin/Company/Upsert/${data}" class="btn btn-success mx-2">
                               <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a onClick=Delete('/admin/company/delete/${data}') class="btn btn-danger mx-2">
                               <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>
                    `;
                }, "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Delete failed:", error);
                    toastr.error("Error occurred while deleting: " + error);
                }
            })
        }
    });
}
