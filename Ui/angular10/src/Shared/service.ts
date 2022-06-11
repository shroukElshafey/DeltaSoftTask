import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Task} from '../Shared/task'
import { Member } from './member';
@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl="https://localhost:44376/api";
  constructor(private http:HttpClient) { }
  task:Task=new Task(0,1,"cwewe","",false,new Member(1,"eefewf"))
  getTaskList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Task/GetAllTasks');
  }

  addTask(val:any){
    return this.http.post(this.APIUrl+'/Task',val);

    }
  getMemberList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Member/GetAll');
  }
  CheckCompleted(Id:number,item:Task)
  {
    return this.http.put(this.APIUrl+"/Task", item);
  }
}
