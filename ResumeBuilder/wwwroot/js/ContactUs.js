var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#ContactUs').DataTable({
        "ajax": {
            "url": "/Admin/ResumeTemplates/GetAllContactFeedBack"
        },
        "columns": [
            { "data": "firstName", "width": "15%" },
            { "data": "lastName", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "message", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <td>
                           <a class="btn btn-warning mx-2"
                               href="#">
                           <i class="bi bi-pencil"></i> <span class="d-none
                                d-xl-inline">&nbsp; Detail</span></a>
                        </td>
                        `
                }, "width": "22%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload()
                        toastr.success(data.message)
                    }
                    else {
                        toastr.error(data.message)
                    }
                }
            })
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalDeleteWithBootstrapButtons.fire(
                'Cancelled',
                'Your file was not deleted.',
                'info'
            )
        }
    })
}