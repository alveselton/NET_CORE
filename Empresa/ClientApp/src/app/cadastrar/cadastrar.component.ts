import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Empresa } from '../models/empresa';
import { EmpresaService } from '../services/empresa.service';

@Component({
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html',
  styleUrls: ['./cadastrar.component.css']
})
export class CadastrarComponent implements OnInit {

  status: string = "blank";
  statusErrorMensagem = false;
  mensagemErro: string = "";

  @Input() codigo: string = "";
  @Input() razaoSocial: string = "";
  @Input() cnpj: string = "";
  @Input() isEdit: boolean = false;
  @Input() dataCadastro?: Date;


  @Input() titulo: string = !this.isEdit ? "Cadastrar Empresa": '';

 
  empresa: Empresa = { codigo: '', razaoSocial: '', cnpj: '', dataCadastro: undefined };

  constructor(public router: Router, private empresaService: EmpresaService) { }

  ngOnInit(): void {
    this.status = "blank";
  }

  ngSalvar() {
    this.empresa.codigo = this.codigo;
    this.empresa.cnpj = this.cnpj;
    this.empresa.razaoSocial = this.razaoSocial;

    if (!!this.isEdit) {
      this.empresa.dataCadastro = this.dataCadastro;
      this.ngAtualizar(this.empresa)
    } else {
      this.ngInserir(this.empresa);
    }
  }

  ngInserir(empresa: Empresa) {
    this.empresaService.incluirEmpresa(empresa)
      .subscribe(data => {
          console.log('inserir sucesso');
        this.status = "success"
        this.statusErrorMensagem = true;
      }, err => {
        console.log('inserir error');
        this.statusErrorMensagem = false;
          this.status = "error"
      })
  }

  ngAtualizar(empresa: Empresa) {
    this.empresaService.atualizarEmpresa(empresa).subscribe(data => {
      console.log('Atualizar sucesso');
      this.statusErrorMensagem = true;
      this.status = "success"

    }, err => {
      console.log('Atualizar error');
      this.statusErrorMensagem = false;
      this.status = "error"
    })
  }

  tentarNovamente() {
    this.mensagemErro = "";
    this.status = "";
  }
}
