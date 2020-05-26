import React, { Component } from 'react';

import profile from "./data";



class SkillDetail extends Component {

    render() {

        return (

            <div>

                {

                    profile.Skills.map((skill) => {

                        return (

                            <div>

                                <h4>{skill.Area}</h4>

                                <ul>

                                    {

                                        skill.SkillSet.map((skillDetail) => {

                                            return (

                                                <li>

                                                    {skillDetail.Name}

                                                </li>

                                            );

                                        })

                                    }

                                </ul>

                            </div>

                        );

                    })

                }

            </div>

        );

    }

}

export default SkillDetail;