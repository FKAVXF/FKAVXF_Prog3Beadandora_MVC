package controller;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import model.owners;
import model.queriedOwners;
import model.schools;

@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
public class LogiService implements Serializable {
    
    public static LogiService instance;

    public LogiService() {
        schools first = new schools();
        first.setCountry("Hungary");
        first.setCity("Budapest");
        first.setZipCode(1050);
        first.setAddress("Kisteleki ut 3");
        first.setNumberOfChildren(30);
        
        owners second = new owners();
        second.setName("Korosi Gyozo");
        second.setCity("Budapest");
        second.setStartYear(2010);
        second.setHasPaidThisYear(true);
        second.setIsReplaceable(false);
        second.getSchools().add((first));
        
        owners.add(second);
        
        schools third = new schools();
        third.setCountry("Hungary");
        third.setCity("Kecskemet");
        third.setZipCode(1060);
        third.setAddress("Karaly utca 4");
        third.setNumberOfChildren(10);
        
        schools fourth = new schools();
        fourth.setCountry("Hungary");
        fourth.setCity("Kiskunhalas");
        fourth.setZipCode(1160);
        fourth.setAddress("Sandor utca 45");
        fourth.setNumberOfChildren(20);
        
        owners fifth = new owners();
        fifth.setName("Janosi Erzsebet");
        fifth.setCity("Kecskemét");
        fifth.setStartYear(1910);
        fifth.setHasPaidThisYear(false);
        fifth.setIsReplaceable(false);
        fifth.getSchools().add((third));
        fifth.getSchools().add((fourth));
        
        owners.add(fifth);
    }
    
    public static LogiService getInstance() {
        if (instance == null) {
            instance = new LogiService();
        }
        return instance;
    }
    @XmlElement
    List<owners> owners = new ArrayList<>();

    public List<owners> getOwners() {
        return owners;
    }
    
    public queriedOwners getQueriedOwners(String owner)
    {
        queriedOwners local = new queriedOwners();
        for (owners o : owners) {
            if (o.getName().equals(owner)) {
                //local.setQueriedList((ArrayList<schools>) o.getSchools());
                local.setOwner(o); 
            }
            
        }
        return local;
    }
    
}
