import React, { Component } from 'react'
import AccountService from '../services/AccountService';

class AccountListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                accounts: []
        }
        this.addAccount = this.addAccount.bind(this);
        this.editAccount = this.editAccount.bind(this);
        this.deleteAccount = this.deleteAccount.bind(this);
    }

    deleteAccount(id){
        AccountService.deleteAccount(id).then( res => {
            this.setState({accounts: this.state.accounts.filter(account => account.id !== id)});
        });
    }
    viewAccount(id){
        this.props.history.push(`/view-account/${id}`);
    }
    editAccount(id){
        console.log("editing " + id)
        this.props.history.push(`/add-account/${id}`);
    }

    componentDidMount(){
        AccountService.getAccounts().then((res) => {
            this.setState({ accounts: res.data});
        });
    }

    addAccount(){
        this.props.history.push('/add-account/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Account List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addAccount}> Add Account</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Account ID</th>
                                    
                                    <th>Organization</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Type</th>
                                    
                                    <th>Balance</th>
                                    
                                    <th>Created</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.accounts.map(
                                        account => 
                                        <tr key = {@(Model.DomainVar).id}>

                                                <td> {account.id)} </td>  
                                                
                                                <td> {account.org_id)} </td>  
                                                
                                                <td> {account.account_name)} </td>  
                                                
                                                <td> {account.account_type)} </td>  
                                                
                                                <td> {account.balance)} </td>  
                                                
                                                <td> {account.created_date)} </td>  
                                                
                                                <td> {account.is_active)} </td>  
                                                
                                                <td> {account.created_by)} </td>  
                                                
                                                <td> {account.last_updated)} </td>  
                                                
                                                <td> {account.last_updated_by)} </td>  
                                                
                                                <td> {account.version)} </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editAccount(account.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteAccount(account.id)} className="btn btn-danger">Delete </button>
                                                
                                             </td>
                                        </tr>
                                    )
                                }
                            </tbody>
                        </table>

                 </div>

            </div>
        )
    }
}

export default AccountListComponent;