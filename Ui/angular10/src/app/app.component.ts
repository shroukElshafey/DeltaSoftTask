import { Component,Input } from '@angular/core';
import { SharedService } from '../Shared/service';
import { Task } from '../Shared/task';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular10';
  TaskList:any=[];
  MemberList:any=[];
  keyword = 'memberName';
  @Input() dataItem:any;
  task: Task = new Task(0, 0, "", "", false,null);
  TaskId:number=0;
  Description:string="";
  DeliverDate:string="";
  IsDone:boolean=false;
  Member:any=[];
  MemberId:number=0;
  MemberName:string="";
  constructor(private SharedService:SharedService){
 
  }
 
  ngOnInit(): void {
    this.refreshTaskList();
    this.loadMemberList();
  }
  loadMemberList(){
    this.SharedService.getTaskList().subscribe((data:any)=>{
      this.TaskList=data;
      console.log(this.dataItem.MemberName)
     // this.MemberId=this.task.MemberId;
      this.MemberName=this.dataItem.MemberName;
    });
  }

  addTask(){
    var val = {TaskId:this.TaskId,
      Description:this.Description,
      DeliverDate:this.DeliverDate,
             IsDone:this.IsDone,
             Member:this.Member,
             MemberId:this.MemberId,
          MemberName:this.MemberName};
    // var val = {TaskId:0,
    //   Description:"oooooojjjjjjjjjjjjjjjjjjj",
    //   DeliverDate:"2020-02-03",
    //          IsDone:true,
    //          Member:null,
    //          MemberId:1,
    //       MemberName:"iiii"};

    this.SharedService.addTask(val).subscribe(res=>{
      alert(res.toString());
     this.refreshTaskList();
    });
  }

  refreshTaskList(){
     this.SharedService.getTaskList().subscribe(data=>{
       this.TaskList=data; 
           // console.log(this.TaskList);

     });
  }
  GetAllMembers() {
    this.SharedService.getMemberList().subscribe(res => {
      this.MemberList = JSON.parse(JSON.stringify(res));
    })
  }
  selectEvent(item: any) {
    this.MemberId = item.MemberId;
    this.Member=item;
  }
  onCheckboxChange(item: Task, e: any) {

    if (e.target.checked) {
      item.IsDone = true;
      this.SharedService.CheckCompleted(item.TaskId, item).subscribe(res => {
        this.TaskList = JSON.parse(JSON.stringify(res));
      });
    }
  }
  onChangeSearch(val: string) {

    this.MemberList.some((elem: any) => {
      if (!(elem.memberName.toString().toLowerCase() === val.toLowerCase())) {
        this.MemberId= 0;
      }
      else {
        this.MemberId = elem.member_Id;
        throw true;
      }
    });
  }
}
