import React, { Component } from 'react'
import ActionGroupMapService from '../services/action_group_map-service';
import { withNavigation } from './with-navigation';


class ActionGroupMapCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    action_id: '' ,
                
                    action_group_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeActionIdHandler = this.changeActionIdHandler.bind(this);
                                    
                    this.changeActionGroupIdHandler = this.changeActionGroupIdHandler.bind(this);
                        this.saveOrUpdateActionGroupMap = this.saveOrUpdateActionGroupMap.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("ActionGroupMap componentDidMount() ID= " + this.state.id )
            ActionGroupMapService.getActionGroupMapById(this.state.id).then( (res) =>{
                let actiongroupmap = res.data;
                this.setState({

                            id: actiongroupmap.id ,
                        
                            action_id: actiongroupmap.action_id ,
                        
                            action_group_id: actiongroupmap.action_group_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateActionGroupMap = (e) => {
        e.preventDefault();
        let actiongroupmap = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    action_id: this.state.action_id , 
                            
                    action_group_id: this.state.action_group_id  
                        };
        console.log('actiongroupmap => ' + JSON.stringify(actiongroupmap));

        // step 5
        if(this.state.id === '_add'){
            ActionGroupMapService.createActionGroupMap(actiongroupmap).then(res =>{
                this.props.navigate('/actiongroupmap');
            });
        }else{
            ActionGroupMapService.updateActionGroupMap(actiongroupmap, this.state.id).then( res => {
                this.props.navigate('/actiongroupmap');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeActionIdHandler= (event) => {
            this.setState({action_id: event.target.value});
        }
        
        changeActionGroupIdHandler= (event) => {
            this.setState({action_group_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/actiongroupmap');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add ActionGroupMap</h3>
        }else{
            return <h3 className="text-center">Update ActionGroupMap</h3>
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
                                            <label> Security Group Map ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Action ID: </label>
                                            <input placeholder="" name="action_id" className="form-control" 
                                                value={this.state.action_id} onChange={this.changeActionIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Organization: </label>
                                            <input placeholder="" name="action_group_id" className="form-control" 
                                                value={this.state.action_group_id} onChange={this.changeActionGroupIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateActionGroupMap}>Save</button>
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

export default withNavigation(ActionGroupMapCreateComponent);