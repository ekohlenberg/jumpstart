import React, { Component } from 'react'
import AccountService from '../services/AccountService';



class AccountCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    org_id: '' ,
                
                    account_name: '' ,
                
                    account_type: '' ,
                
                    balance: '' ,
                
                    created_date: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeOrgIdHandler = this.changeOrgIdHandler.bind(this);
                                    
                    this.changeAccountNameHandler = this.changeAccountNameHandler.bind(this);
                                    
                    this.changeAccountTypeHandler = this.changeAccountTypeHandler.bind(this);
                                    
                    this.changeBalanceHandler = this.changeBalanceHandler.bind(this);
                                    
                    this.changeCreatedDateHandler = this.changeCreatedDateHandler.bind(this);
                        this.saveOrUpdateAccount = this.saveOrUpdateAccount.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Account componentDidMount() ID= " + this.state.id )
            AccountService.getAccountById(this.state.id).then( (res) =>{
                let account = res.data;
                this.setState({

                            id: account.id ,
                        
                            org_id: account.org_id ,
                        
                            account_name: account.account_name ,
                        
                            account_type: account.account_type ,
                        
                            balance: account.balance ,
                        
                            created_date: account.created_date 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateAccount = (e) => {
        e.preventDefault();
        let account = {

                    id: this.state.id , 
                
                    org_id: this.state.org_id , 
                
                    account_name: this.state.account_name , 
                
                    account_type: this.state.account_type , 
                
                    balance: this.state.balance , 
                
                    created_date: this.state.created_date  
                        };
        console.log('account => ' + JSON.stringify(account));

        // step 5
        if(this.state.id === '_add'){
            AccountService.createAccount(account).then(res =>{
                this.props.history.push('/account');
            });
        }else{
            AccountService.updateAccount(account, this.state.id).then( res => {
                this.props.history.push('/account');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeOrgIdHandler= (event) => {
            this.setState({org_id: event.target.value});
        }
        
        changeAccountNameHandler= (event) => {
            this.setState({account_name: event.target.value});
        }
        
        changeAccountTypeHandler= (event) => {
            this.setState({account_type: event.target.value});
        }
        
        changeBalanceHandler= (event) => {
            this.setState({balance: event.target.value});
        }
        
        changeCreatedDateHandler= (event) => {
            this.setState({created_date: event.target.value});
        }
            cancel(){
        this.props.history.push('/account');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Account</h3>
        }else{
            return <h3 className="text-center">Update Account</h3>
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
                                            <label> Account ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Organization: </label>
                                            <input placeholder="" name="org_id" className="form-control" 
                                                value={this.state.org_id} onChange={this.changeOrgIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Name: </label>
                                            <input placeholder="" name="account_name" className="form-control" 
                                                value={this.state.account_name} onChange={this.changeAccountNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Type: </label>
                                            <input placeholder="" name="account_type" className="form-control" 
                                                value={this.state.account_type} onChange={this.changeAccountTypeHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Balance: </label>
                                            <input placeholder="" name="balance" className="form-control" 
                                                value={this.state.balance} onChange={this.changeBalanceHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Created: </label>
                                            <input placeholder="" name="created_date" className="form-control" 
                                                value={this.state.created_date} onChange={this.changeCreatedDateHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateAccount}>Save</button>
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

export default AccountCreateComponent;