
package model;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "queriedOwners")
@XmlAccessorType(XmlAccessType.FIELD)
public class queriedOwners implements Serializable {
    @XmlElement(name = "owner")
    private owners owner;
    @XmlElement(name = "school")
    List<schools> schools;

    public void setOwner(owners owner) {
        this.owner = owner;
    }
    
    public owners getOwner() {
        return owner;
    }

    public List<schools> getSchools() {
        return schools;
    }

    public void setQueriedList(ArrayList<schools> List)
    {
        this.schools = List;
    }
}
