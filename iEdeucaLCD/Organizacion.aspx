<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Organizacion.aspx.vb" MasterPageFile="~/Inicio.Master" Inherits="iEdeucaLCD.Organizacion" %>
<asp:Content ID="head" ContentPlaceHolderID="Inicio" runat="server">
        <div class="card card-custom">
        <div class="row">
            <div class="col-md-12">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card-title">
                                <h3 class="card-label">Organización</h3>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="card-title">
                                <button class="btn btn-outline-primary btn-icon-sm" data-target="#create" data-toggle="modal" type="button" id="btnIngresar">
                                    <i class="flaticon2-plus"></i>
                                    Nueva Organización
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card-body">
            <div class="container" style="overflow-x: auto;">
                <table class="table table-striped- table-bordered table-hover table-checkable" id="tabla_id">
                    <thead>
                        <tr>
                            <th>Acción</th>
                            <th>Id</th>
                            <th>Nombre</th>
                            <th>Tipo de Organización</th>
                            <th>Nombre Corto</th>
                          
                        </tr>
                    </thead>
                    <tbody id="mostrar">
                        <%--    <tr>
                             <td>
                                   
								<a ><i class='fa fa-pencil-alt'> </i></a>
							    <a><i class='fa fa-trash-alt'> </i>  </a> 
                             </td>
                         </tr>--%>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <!--Modal Create-->
    <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="create" role="dialog" tabindex="-1">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Nueva Organización
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button"></button>

                </div>
                <div class="modal-body">
                    <form class="needs-validation was-validated" novalidate="" id="form_valid" name="form_valid">
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label>Nombre</label>
                                <input type="hidden" value="0" id="PersonId" />
                               



                                <input type="text" class="form-control" id="Nombre" name="Nombre" required="">
                                <%--<div class="invalid-feedback">Ingresa tu Primer Nombre. </div>--%>
                            </div>
                             <div class="col-md-6 mb-3">
                                <label>Tipo de Organización</label>
                                <select class="custom-select d-block w-100" id="tipo_organizacion"  required="">
                                    <option value="">Seleccione...</option>
                                    <option value="0">Si</option>
                                    <option value="1">No</option>
                                </select>
                                <%--<div class="invalid-feedback">Seleccione una opción. </div>--%>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label>Nombre Corto</label>
                                <input type="text" class="form-control" id="segundoNombre" name="segundoNombre" required="">
                                <%--<div class="invalid-feedback">Ingresa tu Segundo Nombre. </div>--%>
                            </div>
         
                        </div>

                    </form>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal" type="button">
                        Cancelar
                    </button>


                    <button class="btn btn-primary btn_agregar" type="button" id="btnAgregar">Guardar</button>


                </div>

            </div>
        </div>

    </div>
</asp:Content>

