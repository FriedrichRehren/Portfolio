import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Project } from './_models/project';
import { Domain } from './_models/domain';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  
  baseUrl: string = 'https://localhost:7187/';


  constructor(private http: HttpClient) { }
  
  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.baseUrl + 'projects')
  }
  getDomains(): Observable<Domain[]> {
    return this.http.get<Domain[]>(this.baseUrl + 'domains')
  }
}
