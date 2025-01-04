import React, { Component } from 'react'
import OrgService from '../services/org-service';



class OrgCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    name: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                        this.saveOrUpdateOrg = this.saveOrUpdateOrg.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Org componentDidMount() ID= " + this.state.id )
            OrgService.getOrgById(this.state.id).then( (res) =>{
                let org = res.data;
                this.setState({

                            id: org.id ,
                        
                            name: org.name 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateOrg = (e) => {
        e.preventDefault();
        let org = {

                    id: this.state.id , 
                
                    name: this.state.name  
                        };
        console.log('org => ' + JSON.stringify(org));

        // step 5
        if(this.state.id === '_add'){
            OrgService.createOrg(org).then(res =>{
                this.props.history.push('/org');
            });
        }else{
            OrgService.updateOrg(org, this.state.id).then( res => {
                this.props.history.push('/org');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
            cancel(){
        this.props.history.push('/org');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Org</h3>
        }else{
            return <h3 className="text-center">Update Org</h3>
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
                                            <label> Organization ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Name: </label>
                                            <input placeholder="" name="name" className="form-control" 
                                                value={this.state.name} onChange={this.changeNameHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateOrg}>Save</button>
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

export default OrgCreateComponent;