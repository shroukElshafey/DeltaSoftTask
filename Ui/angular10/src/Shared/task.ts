import { Member } from "./member";

export class Task {
    TaskId :number;
    MemberId :number;
    Description :string;
    DeliverDate:string;
    IsDone:boolean;
    Member?:any;
    constructor(_TaskId: number,_MemberId:number, _Description :string,_DeliverDate :string,_IsDone:boolean,_Member:any) {
        this.TaskId = _TaskId;
        this.MemberId = _MemberId;
        this.Description = _Description;
        this.IsDone = _IsDone;
        this.DeliverDate=_DeliverDate;
        this.Member=_Member;
}
}

