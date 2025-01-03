import React, { Component } from 'react'
import BillService from '../services/BillService';



class BillCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    vendor_id: '' ,
                
                    org_id: '' ,
                
                    bill_number: '' ,
                
                    bill_date: '' ,
                
                    due_date: '' ,
                
                    total_amount: '' ,
                
                    status: '' ,
                
                    created_date: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeVendorIdHandler = this.changeVendorIdHandler.bind(this);
                                    
                    this.changeOrgIdHandler = this.changeOrgIdHandler.bind(this);
                                    
                    this.changeBillNumberHandler = this.changeBillNumberHandler.bind(this);
                                    
                    this.changeBillDateHandler = this.changeBillDateHandler.bind(this);
                                    
                    this.changeDueDateHandler = this.changeDueDateHandler.bind(this);
                                    
                    this.changeTotalAmountHandler = this.changeTotalAmountHandler.bind(this);
                                    
                    this.changeStatusHandler = this.changeStatusHandler.bind(this);
                                    
                    this.changeCreatedDateHandler = this.changeCreatedDateHandler.bind(this);
                        this.saveOrUpdateBill = this.saveOrUpdateBill.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Bill componentDidMount() ID= " + this.state.id )
            BillService.getBillById(this.state.id).then( (res) =>{
                let bill = res.data;
                this.setState({

                            id: bill.id ,
                        
                            vendor_id: bill.vendor_id ,
                        
                            org_id: bill.org_id ,
                        
                            bill_number: bill.bill_number ,
                        
                            bill_date: bill.bill_date ,
                        
                            due_date: bill.due_date ,
                        
                            total_amount: bill.total_amount ,
                        
                            status: bill.status ,
                        
                            created_date: bill.created_date 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateBill = (e) => {
        e.preventDefault();
        let bill = {

                    id: this.state.id , 
                
                    vendor_id: this.state.vendor_id , 
                
                    org_id: this.state.org_id , 
                
                    bill_number: this.state.bill_number , 
                
                    bill_date: this.state.bill_date , 
                
                    due_date: this.state.due_date , 
                
                    total_amount: this.state.total_amount , 
                
                    status: this.state.status , 
                
                    created_date: this.state.created_date  
                        };
        console.log('bill => ' + JSON.stringify(bill));

        // step 5
        if(this.state.id === '_add'){
            BillService.createBill(bill).then(res =>{
                this.props.history.push('/bill');
            });
        }else{
            BillService.updateBill(bill, this.state.id).then( res => {
                this.props.history.push('/bill');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeVendorIdHandler= (event) => {
            this.setState({vendor_id: event.target.value});
        }
        
        changeOrgIdHandler= (event) => {
            this.setState({org_id: event.target.value});
        }
        
        changeBillNumberHandler= (event) => {
            this.setState({bill_number: event.target.value});
        }
        
        changeBillDateHandler= (event) => {
            this.setState({bill_date: event.target.value});
        }
        
        changeDueDateHandler= (event) => {
            this.setState({due_date: event.target.value});
        }
        
        changeTotalAmountHandler= (event) => {
            this.setState({total_amount: event.target.value});
        }
        
        changeStatusHandler= (event) => {
            this.setState({status: event.target.value});
        }
        
        changeCreatedDateHandler= (event) => {
            this.setState({created_date: event.target.value});
        }
            cancel(){
        this.props.history.push('/bill');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Bill</h3>
        }else{
            return <h3 className="text-center">Update Bill</h3>
        }
    }
    render() {
        return (
            <div>
                <br></br>
                   <div className = "container">
                        <div className = "row">
                            <div className = "card col-md-6 offset-md-3 offset-md-3">
                                {
                                    this.getTitle()
                                }
                                <div className = "card-body">
                                    <form>
                                        
                    
                                            <div className = "form-group">
                                            <br/>
                                            <label> Bill ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Vendor : </label>
                                            <input placeholder="" name="vendor_id" className="form-control" 
                                                value={this.state.vendor_id} onChange={this.changeVendorIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Organization: </label>
                                            <input placeholder="" name="org_id" className="form-control" 
                                                value={this.state.org_id} onChange={this.changeOrgIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Number: </label>
                                            <input placeholder="" name="bill_number" className="form-control" 
                                                value={this.state.bill_number} onChange={this.changeBillNumberHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Bill Date: </label>
                                            <input placeholder="" name="bill_date" className="form-control" 
                                                value={this.state.bill_date} onChange={this.changeBillDateHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Due Date: </label>
                                            <input placeholder="" name="due_date" className="form-control" 
                                                value={this.state.due_date} onChange={this.changeDueDateHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Total Amount: </label>
                                            <input placeholder="" name="total_amount" className="form-control" 
                                                value={this.state.total_amount} onChange={this.changeTotalAmountHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Status: </label>
                                            <input placeholder="" name="status" className="form-control" 
                                                value={this.state.status} onChange={this.changeStatusHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Created: </label>
                                            <input placeholder="" name="created_date" className="form-control" 
                                                value={this.state.created_date} onChange={this.changeCreatedDateHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateBill}>Save</button>
                                        <button className="btn btn-danger" onClick={this.cancel.bind(this)} style={{marginLeft: "10px"}}>Cancel</button>
                                    </form>
                                </div>
                            </div>
                        </div>

                   </div>
            </div>
        )
    }
}

export default BillCreateComponent;