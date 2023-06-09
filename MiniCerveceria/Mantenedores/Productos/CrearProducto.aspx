﻿<%@ Page Title="Mantenedores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearProducto.aspx.cs" Inherits="MiniCerveceria.Mantenedores.Productos.CrearProducto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="/GlobalCss/Mantenedores.css" rel="stylesheet" type="text/css">

    <style>
		.FormCursoExterno{
			background:#000000;
			color: #ffffff;
			border-radius: 15px;
		}

		.FormCursoInterno{
			background:#ffffff;
			color: #000000;
			border-radius: 15px;
		}

		.CardItem{
			border-radius: 15px;
		}

		#headMaster {
			display: none;
		}

        #mainNav{
            display: none;
        }

        #footerDefault{
            display: none;
        }

		#barraNav {
            background: #000000 !important;
            color: #ffffff;
            border-radius: 15px;
        }
        #image {
            display: block;
            width: 100%;
        }
        .preview {
            overflow: hidden;
            width: 160px; 
            height: 160px;
            margin: 10px;
            border: 1px solid red;
        }
        #flImagen{
            border: 5px dotted #000;
            border-radius:50px;
            padding: 2px;
            font-size: 20px;
        }
        #flImagen::-webkit-file-upload-button{
            background:#000;
            color: #fff;
            padding: 8px 16px;
            border: none;
            border-radius: 50px;
            cursor: pointer;
        }
	</style>

	<nav id="barraNav" class="navbar bg-body-tertiary">
	  <div class="container">
		<a runat="server" href="~/Mantenedores/Productos/DefaultProductos.aspx"> 
			<img id="imgButtonBack" src="/Imagenes/Iconos/BackButtonWithe.png" height="40"> 
		</a>
		<div class="row">
			<div class="col-2">
				<img src="/Imagenes/Iconos/ProductosWithe.png" height="40" width="40">
			</div>
			<div class="col-10">
				<asp:Label CssClass="titulo" style="font-size:1.9em; color: #ffffff;" runat="server" ClientIDMode="Static" id="CambioNomVentana"></asp:Label>
			</div>
		</div>
		<a id="btnGuardar" style="cursor:pointer"> 
			<img src="/Imagenes/Iconos/BotonGuardarWithe.png" class="d-flex" height="40" width="40">
		</a>
		<asp:Button runat="server" ClientIDMode="Static" ID="btnGuardarHide" CssClass="visually-hidden" OnClick="btnCrearProducto_Click"/>
		<asp:Button runat="server" ClientIDMode="Static" ID="btnActualizarHide" CssClass="visually-hidden" OnClick="btnModificarProducto_Click"/>
		<asp:HiddenField runat="server" ClientIDMode="Static" Value="" ID="update"/>
		<asp:HiddenField runat="server" ClientIDMode="Static" Value="" ID="hdnEstado"/>
	  </div>
	</nav>
	<br />
	<div>
		<div class="container">
		  <div class="row">
			<div class="col-lg-8">
				<br />
				<div class="card FormCursoExterno">
				  <br />
				  <div class="card-body">
					  <asp:Label  CssClass="titulo" style="font-size:1.9em; color: #ffffff;" id="lblNombreItem" ClientIDMode="Static" runat="server"></asp:Label>
					  <br />
					  <br />
					  <div class="row mb-3">
						<div class="col-lg-12">
						  <div class="form-outline">
							<asp:textbox runat="server" ClientIDMode="Static" type="text" id="txtNombreProducto" maxlength="499" placeholder="Nombre producto" class="form-control" />
							<label class="form-label">Nombre producto</label>
						  </div>
						</div>
					  </div>
					  <div class="row mb-3">
						<div class="col-lg-4">
						  <div class="form-outline">
							<asp:textbox runat="server" ClientIDMode="Static" type="text" id="txtPrecioProucto" maxlength="15" class="form-control isNumero" placeholder="999.999"/>
							<label class="form-label">Precio</label>
						  </div>
						</div>
						<div class="col-lg-4">
						  <div class="form-outline">
							<asp:DropDownList runat="server" ClientIDMode="Static" id="cboCategoria" class="form-select">
								<asp:ListItem selected="true" value="0">Seleccione...</asp:ListItem>
								<asp:ListItem value="1">Ingredientes</asp:ListItem>
								<asp:ListItem value="2">Accesorios</asp:ListItem>
								<asp:ListItem value="3">Cristaleria</asp:ListItem>
								<asp:ListItem value="4">Equipamiento</asp:ListItem>
								<asp:ListItem value="5">Libros y recetas</asp:ListItem>
							</asp:DropDownList>
							<label class="form-label">Categoria</label>
						  </div>
						</div>
						<div class="col-lg-4">
						  <div class="form-outline">
							<asp:HiddenField runat="server" ClientIDMode="Static" Value="" ID="hdnSubCate"/>
							<asp:DropDownList runat="server" ClientIDMode="Static" id="cboSubCategoria" class="form-select">
							</asp:DropDownList>
							<label class="form-label">Sub categoria</label>
						  </div>
						</div>
					  </div>
					  <div class="row mb-3">
						<div class="col-lg-6">
						  <div class="form-outline">
							<asp:textbox runat="server" ClientIDMode="Static" type="text" id="txtFechaCreacion" readonly="true" placeholder="00/00/0000" class="form-control" />
							<label class="form-label">Fecha crecion</label>
						  </div>
						</div>
						<div class="col-lg-6">
						  <div class="form-outline">
							<asp:textbox runat="server" ClientIDMode="Static" type="text" id="txtFechaModificacion" readonly="true" placeholder="00/00/0000" class="form-control" />
							<label class="form-label">Fecha modificacion</label>
						  </div>
						</div>
					  </div>
					  <div class="row mb-1">
						  <asp:textbox runat="server" ClientIDMode="Static" TextMode="MultiLine" class="form-control" style="max-width:97%;margin-left:10px;" maxlength="2999" id="txtDescripcion" rows="3"/>
						  <label class="form-label">Descripcion</label>
					  </div>
				  </div>
				</div>
			</div>
			<div class="col-lg-4">
                <div class="container">
                    <h5>Upload Images</h5> 
                    <form method="post">
                        <asp:FileUpload ClientIDMode="Static" runat="server" type="file" name="image" class="image" ID="flImagen" style="width:100%;" />
                        <asp:image ID="imagenRecortada" ClientIDMode="Static" style="width:100%;border-radius: 5%;border: 5px solid #000;" runat="server" />
                    </form>
                </div>
                <asp:HiddenField  id="hdnRuta" ClientIDMode="Static" runat="server" />
                <div class="modal fade" id="modal" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="modalLabel">Crop image</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="img-container">
                                    <div class="row">
                                        <div class="col-md-8">  
                                            <!--  default image where we will set the src via jquery-->
                                            <img id="image">
                                        </div>
                                        <div class="col-md-4">
                                            <div class="preview"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal" id="cancel">Cancel</button>
                                <button type="button" class="btn btn-primary" id="crop">Crop</button>
                            </div>
                        </div>
                    </div>
                </div>
		    </div>
		</div>
	</div>
	<br />
	<script>
        var bs_modal = $('#modal');
        var image = document.getElementById('image');
        var cropper, reader, file;

        $("body").on("change", ".image", function (e) {
            var files = e.target.files;
            var done = function (url) {
                image.src = url;
                bs_modal.modal('show');
            };


            if (files && files.length > 0) {
                file = files[0];

                if (URL) {
                    done(URL.createObjectURL(file));
                } else if (FileReader) {
                    reader = new FileReader();
                    reader.onload = function (e) {
                        done(reader.result);
                    };
                    reader.readAsDataURL(file);
                }
            }
        });

        bs_modal.on('shown.bs.modal', function () {
            cropper = new Cropper(image, {
                aspectRatio: 1,
                viewMode: 3,
                preview: '.preview'
            });
        }).on('hidden.bs.modal', function () {
            cropper.destroy();
            cropper = null;
        });

        $("#crop").click(function () {
            canvas = cropper.getCroppedCanvas({
                width: 800,
                height: 800,
            });
            
            canvas.toBlob(function (blob) {
                url = URL.createObjectURL(blob);
                $("#imagenRecortada").attr('src', url);

                var reader = new FileReader();
                reader.readAsDataURL(blob);
                reader.onloadend = function () {
                    var base64data = reader.result;
                    $("#image").src = base64data;
                    $("#hdnRuta").val(base64data);


                    bs_modal.modal('hide');
                };
            });
            
            
        });
        $("#cancel").click(function () {
            bs_modal.modal('hide');
        });
        $(document).ready(function () {
            $("#btnGuardarHide").on('submit', function (eve) {
                eve.preventDefault();
            });

			$('#btnGuardar').on('click', function () {
                var update = $('#update').val()
                console.log("entre a esta wea");

                var nom = $('#txtNombreProducto').val();
                var precio = $('#txtPrecioProucto').val(); 
                var cate = $('#cboCategoria').val(); 
                var subcate = $('#cboSubCategoria').val(); 
                var descc = $('#txtDescripcion').val(); 

                if (nom == "") {
                    Command: toastr["warning"]("Debe ingresar el nombre del producto")
                    return;
                }

                if (precio == "" || precio == 0 || precio == "0") {
                    Command: toastr["warning"]("Debe ingresar el precio del producto")
                    return;
                }

                if (cate == "0" || cate == 0) {
                    Command: toastr["warning"]("Debe seleccionar la categoria a la cual pertenece el producto")
                    return;
                }

                if (true) {

                }

                if (update != "") {
                    $('#btnActualizarHide').click()
                } else {
                    $('#btnGuardarHide').click()
                }
			})

			$('#cboCategoria').on('change', function () {
				var option = $('#cboCategoria').val();

				var html = "";

				$('#cboSubCategoria').html('');

                console.log(option);

				if (option == '1') {
                    html += "<option value='0'>Seleccione...</option>";
					html += "<option value='1'>Azúcares & Extractos</option>";
                    html += "<option value='2'>Clarificantes</option>";
                    html += "<option value='3'>Sales & aditivos</option>";
					html += "<option value='4'>Maltas</option>";
					html += "<option value='5'>Levaduras</option>";
					html += "<option value='6'>Lupulos</option>";

                    $('#cboSubCategoria').html(html)
                }

				if (option == '2') {
                    html += "<option value='0'>Seleccione...</option>";
                    html += "<option value='7'>Embotellado</option>";
                    html += "<option value='8'>Fermentacion</option>";
                    html += "<option value='9'>Filtros</option>";
                    html += "<option value='10'>Medicion</option>";
                    html += "<option value='11'>Fogones</option>";
                    html += "<option value='12'>Enfriamiento</option>";

                    $('#cboSubCategoria').html(html)
				}

                if (option != '1' && option != '2') {
                    $('#hdnSubCate').val("0")
                }
			})

			$('#cboSubCategoria').on('change', function () {
				var valueSelected = $('#cboSubCategoria').val();

                $('#hdnSubCate').val(valueSelected)
            })
        });
    </script>
</asp:Content>

