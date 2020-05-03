package model;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "owner")
@XmlAccessorType(XmlAccessType.FIELD)
public class owners implements Serializable {
    private static int nextID;
    @XmlElement
    private int owner_ID;
    @XmlElement
    private int startYear;
    @XmlElement
    private String name;
    @XmlElement
    private String city;
    @XmlElement
    private boolean hasPaidThisYear;
    @XmlElement
    private boolean isReplaceable;
    @XmlElement
    private List<schools> schools = new ArrayList<>();

    public owners() {
        this.owner_ID = nextID++;
    }

    public List<schools> getSchools() {
        return schools;
    }
    
    public int getOwner_ID() {
        return owner_ID;
    }

    public int getStartYear() {
        return startYear;
    }

    public void setStartYear(int startYear) {
        this.startYear = startYear;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public boolean isHasPaidThisYear() {
        return hasPaidThisYear;
    }

    public void setHasPaidThisYear(boolean hasPaidThisYear) {
        this.hasPaidThisYear = hasPaidThisYear;
    }

    public boolean isIsReplaceable() {
        return isReplaceable;
    }

    public void setIsReplaceable(boolean isReplaceable) {
        this.isReplaceable = isReplaceable;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 59 * hash + this.owner_ID;
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final owners other = (owners) obj;
        if (this.owner_ID != other.owner_ID) {
            return false;
        }
        return true;
    }
    
}
