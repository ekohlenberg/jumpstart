import React, { Component } from 'react'
import BillItemService from '../services/bill_item-service';
import { withNavigation } from './with-navigation';


class BillItemCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    bill_id: '' ,
                
                    description: '' ,
                
                    quantity: '' ,
                
                    unit_price: '' ,
                
                    total_amount: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeBillIdHandler = this.changeBillIdHandler.bind(this);
                                    
                    this.changeDescriptionHandler = this.changeDescriptionHandler.bind(this);
                                    
                    this.changeQuantityHandler = this.changeQuantityHandler.bind(this);
                                    
                    this.changeUnitPriceHandler = this.changeUnitPriceHandler.bind(this);
                                    
                    this.changeTotalAmountHandler = this.changeTotalAmountHandler.bind(this);
                        this.saveOrUpdateBillItem = this.saveOrUpdateBillItem.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("BillItem componentDidMount() ID= " + this.state.id )
            BillItemService.getBillItemById(this.state.id).then( (res) =>{
                let billitem = res.data;
                this.setState({

                            id: billitem.id ,
                        
                            bill_id: billitem.bill_id ,
                        
                            description: billitem.description ,
                        
                            quantity: billitem.quantity ,
                        
                            unit_price: billitem.unit_price ,
                        
                            total_amount: billitem.total_amount 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateBillItem = (e) => {
        e.preventDefault();
        let billitem = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    bill_id: this.state.bill_id , 
                            
                    description: this.state.description , 
                            
                    quantity: this.state.quantity , 
                            
                    unit_price: this.state.unit_price , 
                            
                    total_amount: this.state.total_amount  
                        };
        console.log('billitem => ' + JSON.stringify(billitem));

        // step 5
        if(this.state.id === '_add'){
            BillItemService.createBillItem(billitem).then(res =>{
                this.props.navigate('/billitem');
            });
        }else{
            BillItemService.updateBillItem(billitem, this.state.id).then( res => {
                this.props.navigate('/billitem');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeBillIdHandler= (event) => {
            this.setState({bill_id: event.target.value});
        }
        
        changeDescriptionHandler= (event) => {
            this.setState({description: event.target.value});
        }
        
        changeQuantityHandler= (event) => {
            this.setState({quantity: event.target.value});
        }
        
        changeUnitPriceHandler= (event) => {
            this.setState({unit_price: event.target.value});
        }
        
        changeTotalAmountHandler= (event) => {
            this.setState({total_amount: event.target.value});
        }
            cancel(){
        this.props.navigate('/billitem');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add BillItem</h3>
        }else{
            return <h3 className="text-center">Update BillItem</h3>
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
                                            <label> Bill Item ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Bill ID: </label>
                                            <input placeholder="" name="bill_id" className="form-control" 
                                                value={this.state.bill_id} onChange={this.changeBillIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Description: </label>
                                            <input placeholder="" name="description" className="form-control" 
                                                value={this.state.description} onChange={this.changeDescriptionHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Quantity: </label>
                                            <input placeholder="" name="quantity" className="form-control" 
                                                value={this.state.quantity} onChange={this.changeQuantityHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Unit Price: </label>
                                            <input placeholder="" name="unit_price" className="form-control" 
                                                value={this.state.unit_price} onChange={this.changeUnitPriceHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Total Amount: </label>
                                            <input placeholder="" name="total_amount" className="form-control" 
                                                value={this.state.total_amount} onChange={this.changeTotalAmountHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateBillItem}>Save</button>
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

export default withNavigation(BillItemCreateComponent);