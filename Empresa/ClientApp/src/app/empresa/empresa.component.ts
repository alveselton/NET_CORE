import { Component, OnInit } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { Empresa } from '../models/empresa';
import { EMPRESAS } from '../data/empresas';
import { NgxBootstrapIconsModule } from 'ngx-bootstrap-icons';
import { Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EmpresaService } from '../services/empresa.service';
import { catchError, tap } from 'rxjs/operators';

@Component({
  selector: 'app-empresa',
  templateUrl: './empresa.component.html',
  styleUrls: ['./empresa.component.css']
})
export class EmpresaComponent implements OnInit {

  titulo = "Empresas";
  isLoading = false;
  tituloEdicao = "";
  closeModal: string = "";
  isExibirMensagemExcluir = false;

  empresa: Empresa = { codigo: '', razaoSocial: '', cnpj: '', dataCadastro: undefined };


  public empresaSelecionada: Empresa = { codigo: '', razaoSocial: '', cnpj: '', dataCadastro: undefined };

  listaEmpresas: Empresa[] = [];
  empresas$: Observable<Empresa[]>;

  empresaSelect(empresa: Empresa) {
    this.empresaSelecionada = empresa;
  }

  constructor(public router: Router,
    private modalService: NgbModal,
    private empresaService: EmpresaService) {
    this.listaEmpresas = EMPRESAS;
  }

  triggerModal(content: any, empresa?: Empresa) {
    if (!!empresa) {
      this.empresaSelecionada = empresa;
      console.log(empresa);
    }

    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((res) => {
      this.closeModal = `Closed with: ${res}`;
    }, (res) => {
      this.closeModal = `Dismissed ${this.getDismissReason(res)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  ngOnInit() {
    this.getListaEmpresa();
  }

  getListaEmpresa() {
    this.isLoading = true;
    this.empresaService.getListaEmpresas().subscribe(data => {
      this.listaEmpresas = data;
      this.isLoading = false;
    })
  }

  ngDelete() {
    this.isExibirMensagemExcluir = false;
    this.empresaService.excluirEmpresa(this.empresaSelecionada.codigo)
      .subscribe(data => {
        console.log(data != null);

        if (data != null) {
          console.log('excluído');
          this.isExibirMensagemExcluir = true;
          this.getListaEmpresa();
        }
        else {
          this.isExibirMensagemExcluir = false;
        }

        this.isLoading = false;
      })
  }
}
