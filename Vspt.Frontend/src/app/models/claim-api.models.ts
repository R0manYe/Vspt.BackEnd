export class ClaimApiModel{
   id!:string;
   claimName!:string;   
}
export interface ClaimModel{
   id:string;
   claimName:number;
   claimUser:number;
   claimValue:number; 
 }
 export interface ClaimType{
   id:string;   
   name:string;    
 }