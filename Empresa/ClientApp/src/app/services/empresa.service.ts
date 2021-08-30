import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Empresa } from '../models/empresa';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class EmpresaService {

  readonly url = 'http://localhost:5000/Empresa';

  constructor(private http: HttpClient) { }

  getEmpresas(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(`${this.url}`)
      .pipe(
        tap(p => console.log(p)),
        catchError((e) => {
          console.log(e);
          return throwError(e);
        })
      )
  }

  incluirEmpresa(empresa: Empresa) {
    return this.http.post(`${this.url}/`, empresa);
  }

  atualizarEmpresa(empresa: Empresa) {
    return this.http.put(`${this.url}/`, empresa);
  }

  excluirEmpresa(codigo: string) {
    return this.http.delete(`${this.url}/${codigo}`);
  }

  getListaEmpresas() {
    return this.http.get<Empresa[]>(`${this.url}/`);
  }

  getEmpresa(codigo: string) {
    return this.http.get<Empresa>(`${this.url}/${codigo}`);
  }
}
