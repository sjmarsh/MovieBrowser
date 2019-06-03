import { mount } from '@vue/test-utils';
import { shallowMount } from '@vue/test-utils';
import { RouterLinkStub } from '@vue/test-utils';
import moxios from 'moxios';

import Home from '../../src/components/Home.vue';

describe('Home.vue', () => {

  beforeEach(() => {
    moxios.install()
  })

  afterEach(() => {
    moxios.uninstall()
  })

  test('should mount for testing', () => {
    expect(1).toEqual(1);  // make sure testing modules are working
  });

  test('should show loading indicator', () => {
    const wrapper = mount(Home);
    wrapper.setProps({loading: true});
    var loader = wrapper.find('.loader');
    expect(loader.isVisible()).toBe(true);
    var movieList = wrapper.find('.movie-list');
    expect(movieList.exists()).toBe(false);
  });

  test('should hide loading indicator', (done) => {

    const wrapper = shallowMount(Home, { stubs: { RouterLink: RouterLinkStub } });

    moxios.stubRequest('/api/movie', {
      status: 200,
      response: [{"title":"Superman","path":"C:\\Movies\\Superman","coverArt":"data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2w" }]
    });

    moxios.wait(() => {
      expect(wrapper.vm.loading).toBe(false);
      var loader = wrapper.find('.loader');
      expect(loader.exists()).toBe(false);
      var movieList = wrapper.find('.movie-list');
      expect(movieList.isVisible()).toBe(true);
      done();
    })

  });

  test('data set on mount', (done) => {

    const wrapper = shallowMount(Home, { stubs: { RouterLink: RouterLinkStub } });

    moxios.stubRequest('/api/movie', {
      status: 200,
      response: [{"title":"Superman","path":"C:\\Movies\\Superman","coverArt":"data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2w" }]
    });

    moxios.wait(() => {
      expect(wrapper.vm.movies.length).toEqual(1);
      expect(wrapper.vm.movies[0].title).toEqual('Superman');
      expect(wrapper.vm.status).toEqual('Data loaded');      
      done();
    });

  });  
});