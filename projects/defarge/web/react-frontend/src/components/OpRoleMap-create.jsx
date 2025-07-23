import React, { Component } from 'react'
import OpRoleMapService from '../services/op_role_map-service';
import { withNavigation } from './with-navigation';


class OpRoleMapCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    op_id: '' ,
                
                    op_role_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeOpIdHandler = this.changeOpIdHandler.bind(this);
                                    
                    this.changeOpRoleIdHandler = this.changeOpRoleIdHandler.bind(this);
                        this.saveOrUpdateOpRoleMap = this.saveOrUpdateOpRoleMap.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("OpRoleMap componentDidMount() ID= " + this.state.id )
            OpRoleMapService.getOpRoleMapById(this.state.id).then( (res) =>{
                let oprolemap = res.data;
                this.setState({

                            id: oprolemap.id ,
                        
                            op_id: oprolemap.op_id ,
                        
                            op_role_id: oprolemap.op_role_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateOpRoleMap = (e) => {
        e.preventDefault();
        let oprolemap = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    op_id: this.state.op_id , 
                            
                    op_role_id: this.state.op_role_id  
                        };
        console.log('oprolemap => ' + JSON.stringify(oprolemap));

        // step 5
        if(this.state.id === '_add'){
            OpRoleMapService.createOpRoleMap(oprolemap).then(res =>{
                this.props.navigate('/oprolemap');
            });
        }else{
            OpRoleMapService.updateOpRoleMap(oprolemap, this.state.id).then( res => {
                this.props.navigate('/oprolemap');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeOpIdHandler= (event) => {
            this.setState({op_id: event.target.value});
        }
        
        changeOpRoleIdHandler= (event) => {
            this.setState({op_role_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/oprolemap');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add OpRoleMap</h3>
        }else{
            return <h3 className="text-center">Update OpRoleMap</h3>
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
                                            <label> Operation Role Map ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Operation ID: </label>
                                            <input placeholder="" name="op_id" className="form-control" 
                                                value={this.state.op_id} onChange={this.changeOpIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Role ID: </label>
                                            <input placeholder="" name="op_role_id" className="form-control" 
                                                value={this.state.op_role_id} onChange={this.changeOpRoleIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateOpRoleMap}>Save</button>
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

export default withNavigation(OpRoleMapCreateComponent);