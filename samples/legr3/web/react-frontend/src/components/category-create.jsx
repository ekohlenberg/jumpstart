import React, { Component } from 'react'
import CategoryService from '../services/category-service';



class CategoryCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    org_id: '' ,
                
                    category_name: '' ,
                
                    category_type: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeOrgIdHandler = this.changeOrgIdHandler.bind(this);
                                    
                    this.changeCategoryNameHandler = this.changeCategoryNameHandler.bind(this);
                                    
                    this.changeCategoryTypeHandler = this.changeCategoryTypeHandler.bind(this);
                        this.saveOrUpdateCategory = this.saveOrUpdateCategory.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Category componentDidMount() ID= " + this.state.id )
            CategoryService.getCategoryById(this.state.id).then( (res) =>{
                let category = res.data;
                this.setState({

                            id: category.id ,
                        
                            org_id: category.org_id ,
                        
                            category_name: category.category_name ,
                        
                            category_type: category.category_type 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateCategory = (e) => {
        e.preventDefault();
        let category = {

                    id: this.state.id , 
                
                    org_id: this.state.org_id , 
                
                    category_name: this.state.category_name , 
                
                    category_type: this.state.category_type  
                        };
        console.log('category => ' + JSON.stringify(category));

        // step 5
        if(this.state.id === '_add'){
            CategoryService.createCategory(category).then(res =>{
                this.props.history.push('/category');
            });
        }else{
            CategoryService.updateCategory(category, this.state.id).then( res => {
                this.props.history.push('/category');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeOrgIdHandler= (event) => {
            this.setState({org_id: event.target.value});
        }
        
        changeCategoryNameHandler= (event) => {
            this.setState({category_name: event.target.value});
        }
        
        changeCategoryTypeHandler= (event) => {
            this.setState({category_type: event.target.value});
        }
            cancel(){
        this.props.history.push('/category');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Category</h3>
        }else{
            return <h3 className="text-center">Update Category</h3>
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
                                            <label> Category ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Organization ID: </label>
                                            <input placeholder="" name="org_id" className="form-control" 
                                                value={this.state.org_id} onChange={this.changeOrgIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Name: </label>
                                            <input placeholder="" name="category_name" className="form-control" 
                                                value={this.state.category_name} onChange={this.changeCategoryNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Category Type: </label>
                                            <input placeholder="" name="category_type" className="form-control" 
                                                value={this.state.category_type} onChange={this.changeCategoryTypeHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateCategory}>Save</button>
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

export default CategoryCreateComponent;