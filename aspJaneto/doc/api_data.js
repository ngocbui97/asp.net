define({ "api": [
  {
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "varname1",
            "description": "<p>No type.</p>"
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "varname2",
            "description": "<p>With type.</p>"
          }
        ]
      }
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "./doc/main.js",
    "group": "C__Users_ngoc_Desktop_JNT_git_aspJaneto_doc_main_js",
    "groupTitle": "C__Users_ngoc_Desktop_JNT_git_aspJaneto_doc_main_js",
    "name": ""
  },
  {
    "type": "Delete",
    "url": "/Class/XoaLop",
    "title": "Xóa một lớp mới",
    "group": "Lop",
    "permission": [
      {
        "name": "none"
      }
    ],
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp cần xóa</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example: ",
          "content": "{\n\t\tId: \"1\",\n\t\t\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp xóa</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Mã của lớp vừa xóa</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TenLop",
            "description": "<p>Tên của lớp vừa xóa</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "gvcnId",
            "description": "<p>Id của giáo viên chủ nhiệm lớp vừa xóa</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response: ",
          "content": "{\n\t\tId: 1,\n\t\tMaLOp: \"D12CQCN01\",\n\t\tTenLop: \"Công nghệ thông tin 1\",\n\t\tgvcnId: \"1\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 400": [
          {
            "group": "Error 400",
            "type": "string[]",
            "optional": false,
            "field": "Errors",
            "description": "<p>Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ": {json}",
          "content": "{\n\t\t\"Errors\" : [\n\t\t\t\"Mã lớp là trường bắt buộc\",\n\t\t\t\n\t\t]\n}",
          "type": "json"
        }
      ]
    },
    "filename": "./Controllers/LopController.cs",
    "groupTitle": "Lop",
    "name": "DeleteClassXoalop"
  },
  {
    "type": "Get",
    "url": "/lop/GetAll",
    "title": "lấy tất cả thông tin của lớp",
    "group": "Lop",
    "permission": [
      {
        "name": "none"
      }
    ],
    "version": "1.0.0",
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Mã của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TenLop",
            "description": "<p>Tên của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "gvcnId",
            "description": "<p>Id của giáo viên chủ nhiêm</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response: ",
          "content": "{\n\t\tId: 1,\n\t\tMaLOp: \"D12CQCN01\",\n\t\tTenLop: \"Công nghệ thông tin 1\",\n\t\tgvcnId:\"2\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 400": [
          {
            "group": "Error 400",
            "type": "string[]",
            "optional": false,
            "field": "Errors",
            "description": "<p>Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ": {json}",
          "content": "{\n\t\t\"Errors\" : [\n\t\t\t\"Mã lớp là trường bắt buộc\"\n\t\t\t\n\t\t]\n}",
          "type": "json"
        }
      ]
    },
    "filename": "./Controllers/LopController.cs",
    "groupTitle": "Lop",
    "name": "GetLopGetall"
  },
  {
    "type": "Get",
    "url": "/lop/GetbyId",
    "title": "Lấy thông tin lớp theo Id",
    "group": "Lop",
    "permission": [
      {
        "name": "none"
      }
    ],
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example: ",
          "content": "{\n\t\tId=\"1\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Id",
            "description": "<p>của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Mã của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TenLop",
            "description": "<p>Tên của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "gvcnId",
            "description": "<p>Id của giáo viên chủ nhiệm</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response: ",
          "content": "{\n\t\tId: 1,\n\t\tMaLOp: \"D12CQCN01\",\n\t\tTenLop: \"Công nghệ thông tin 1\",\n\t\tgvcndId: \"2\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 400": [
          {
            "group": "Error 400",
            "type": "string[]",
            "optional": false,
            "field": "Errors",
            "description": "<p>Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ": {json}",
          "content": "{\n\t\t\"Errors\" : [\n\t\t\t\"Mã lớp là trường bắt buộc\",\n\t\t\t\n\t\t]\n}",
          "type": "json"
        }
      ]
    },
    "filename": "./Controllers/LopController.cs",
    "groupTitle": "Lop",
    "name": "GetLopGetbyid"
  },
  {
    "type": "Post",
    "url": "/Lop/TaoLop",
    "title": "Tao lớp mới",
    "group": "Lop",
    "permission": [
      {
        "name": "none"
      }
    ],
    "version": "1.0.0",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Ma cua lop moi</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "TenLop",
            "description": "<p>Ten cua lop moi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     MaLop: '001',\n     TenLop: 'Cong nghe thong tin 01'\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Ma cua lop moi vua tao</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TenLop",
            "description": "<p>Ten cua lop moi vua tao</p>"
          },
          {
            "group": "Success 200",
            "type": "long",
            "optional": false,
            "field": "Id",
            "description": "<p>Iid cua lop moi vua tao</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     MaLop: '001'\n     TenLop: 'Cong nghe thong tin 01'\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "400": [
          {
            "group": "400",
            "type": "string[]",
            "optional": false,
            "field": "Errors",
            "description": "<p>Mang cac loi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ": {json}",
          "content": "{\n     \"Errors\": [\n         \"Ma lop la truong bat buoc\",\n         \n     ]\n}",
          "type": "json"
        }
      ]
    },
    "filename": "./Controllers/LopController.cs",
    "groupTitle": "Lop",
    "name": "PostLopTaolop"
  },
  {
    "type": "Put",
    "url": "/Lop/TenLop",
    "title": "Cập nhật lớp mới",
    "group": "Lop",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Mã của lớp cần cập nhật</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     MaLop: '001'\n     \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp vữa cập nhật</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Mã của lớp vữa cập nhật</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TenLop",
            "description": "<p>Tên của lớp vừa cập nhật</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "gvcnId",
            "description": "<p>Id của giáo viên chủ nhiệm vừa cập nhật</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     MaLop: '001'\n     TenLop: 'Cong nghe thong tin 01',\n     gvcnId:'2'\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "400": [
          {
            "group": "400",
            "type": "string[]",
            "optional": false,
            "field": "Errors",
            "description": "<p>Mang cac loi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ": {json}",
          "content": "{\n     \"Errors\": [\n         \"Ma lop la truong bat buoc\"\n         \n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/LopController.cs",
    "groupTitle": "Lop",
    "name": "PutLopTenlop"
  }
] });
